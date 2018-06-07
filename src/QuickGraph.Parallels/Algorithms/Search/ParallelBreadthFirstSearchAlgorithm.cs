using System;
using System.Collections.Generic;

using QuickGraph.Collections;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.Services;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace QuickGraph.Algorithms.Search
{
    /// <summary>
    /// A <b>parallel</b> breath first search algorithm for directed graphs
    /// </summary>
    /// <reference-ref
    ///     idref="gross98graphtheory"
    ///     chapter="4.2"
    ///     />
    /// <reference-ref
    ///     href="http://www.cc.gatech.edu/~bader/papers/MultithreadedBFS-ICPP2006.pdf"
    ///     />
    [Serializable]
    public sealed class ParallelBreadthFirstSearchAlgorithm<TVertex, TEdge, TLocal>
        : RootedAlgorithmBase<TVertex, IVertexListGraph<TVertex, TEdge>>
//      , IVertexPredecessorRecorderAlgorithm<TVertex,TEdge>
//        , IDistanceRecorderAlgorithm<TVertex,TEdge>
        , IVertexColorizerAlgorithm<TVertex, TEdge>
//        , ITreeBuilderAlgorithm<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
        where TLocal : new()
    {
        private readonly IDictionary<TVertex, GraphColor> vertexColors;
        private readonly IQueue<TVertex> vertexQueue;

        private IDictionary<TVertex, int> vertexIndices;
        private int[] vertexIndexedColors;

        public ParallelBreadthFirstSearchAlgorithm(IVertexListGraph<TVertex,TEdge> g)
            : this(g, new QuickGraph.Collections.ConcurrentQueue<TVertex>(), new Dictionary<TVertex, GraphColor>())
        {}

        /// <summary>
        ///
        /// </summary>
        /// <param name="visitedGraph"></param>
        /// <param name="vertexQueue">thread-safe queue</param>
        /// <param name="vertexColors"></param>
        public ParallelBreadthFirstSearchAlgorithm(
            IVertexListGraph<TVertex, TEdge> visitedGraph,
            IQueue<TVertex> vertexQueue,
            IDictionary<TVertex, GraphColor> vertexColors
            )
            : this(null, visitedGraph, vertexQueue, vertexColors)
        { }

        public ParallelBreadthFirstSearchAlgorithm(
            IAlgorithmComponent host,
            IVertexListGraph<TVertex, TEdge> visitedGraph,
            IQueue<TVertex> vertexQueue,
            IDictionary<TVertex, GraphColor> vertexColors
            )
            :base(host, visitedGraph)
        {
            if (vertexQueue == null)
                throw new ArgumentNullException("vertexQueue");
            if (vertexColors == null)
                throw new ArgumentNullException("vertexColors");

            this.vertexColors = vertexColors;
            this.vertexQueue = vertexQueue;
        }

        public GraphColor GetVertexColor(TVertex vertex)
        {
            return (GraphColor)this.vertexIndexedColors[this.vertexIndices[vertex]];
        }

        public event VertexAction<TVertex> InitializeVertex;
        private void OnInitializeVertex(TVertex v)
        {
            var eh = this.InitializeVertex;
            if (eh != null)
                eh(v);
        }

        public event ParallelVertexEventHandler<TVertex, TLocal> StartVertex;
        private void OnStartVertex(TVertex v, ParallelLoopState state, TLocal local)
        {
            var eh = this.StartVertex;
            if (eh!=null)
                eh(this, new ParallelVertexEventArgs<TVertex,TLocal>(v, state, local));
        }

        /// <summary>
        /// Triggered at the end of a level exploration.
        /// </summary>
        /// <remarks>
        /// This event is not concurrent.
        /// </remarks>
        public event EventHandler NextLevel;
        private void OnNextLevel()
        {
            var eh = this.NextLevel;
            if (eh != null)
                eh(this, EventArgs.Empty);
        }

        public event ParallelVertexEventHandler<TVertex, TLocal> ExamineVertex;
        private void OnExamineVertex(TVertex v, ParallelLoopState state, TLocal local)
        {
            var eh = this.ExamineVertex;
            if (eh != null)
                eh(this, new ParallelVertexEventArgs<TVertex, TLocal>(v, state, local));
        }

        public event ParallelVertexEventHandler<TVertex, TLocal> DiscoverVertex;
        private void OnDiscoverVertex(TVertex v, ParallelLoopState state, TLocal local)
        {
            var eh = this.DiscoverVertex;
            if (eh != null)
                eh(this, new ParallelVertexEventArgs<TVertex,TLocal>(v, state, local));
        }

        public event ParallelEdgeEventHandler<TVertex,TEdge, TLocal> ExamineEdge;
        private void OnExamineEdge(TEdge e, ParallelLoopState state, TLocal local)
        {
            var eh = this.ExamineEdge;
            if (eh != null)
                eh(this, new ParallelEdgeEventArgs<TVertex,TEdge,TLocal>(e, state, local));
        }

        public event ParallelEdgeEventHandler<TVertex,TEdge, TLocal> TreeEdge;
        private void OnTreeEdge(TEdge e, ParallelLoopState state, TLocal local)
        {
            var eh = this.TreeEdge;
            if (eh != null)
                eh(this, new ParallelEdgeEventArgs<TVertex,TEdge,TLocal>(e, state, local));
        }

        public event ParallelVertexEventHandler<TVertex,TLocal> FinishVertex;
        private void OnFinishVertex(TVertex v, ParallelLoopState state, TLocal local)
        {
            var eh = this.FinishVertex;
            if (eh != null)
                eh(this, new ParallelVertexEventArgs<TVertex,TLocal>(v, state, local));
        }

        protected override void Initialize()
        {
            // make sure queue is empty
            Contract.Ensures(this.vertexQueue.Count == 0);

            base.Initialize();

            var cancelManager = this.Services.CancelManager;

            // initialize indices and colors
            var vertexCount = this.VisitedGraph.VertexCount;
            this.vertexIndices = new Dictionary<TVertex, int>(vertexCount);
            this.vertexIndexedColors = new int[vertexCount];
            int i = 0;
            foreach(var vertex in this.VisitedGraph.Vertices)
            {
                this.vertexIndices.Add(vertex, i);
                // White = 0, so implicitely set by the runtime
                // this.vertexIndexedColors[i] = (int)GraphColor.White;
                i++;
            }

            // initialize vertex u
            Parallel.ForEach(this.VisitedGraph.Vertices, delegate(TVertex v)
            {
                if (cancelManager.IsCancelling) return;

                OnInitializeVertex(v);
            });

        }

        protected override void InternalCompute()
        {
            if (this.VisitedGraph.VertexCount == 0)
                return;

            TVertex rootVertex;
            IEnumerable<TVertex> roots;
            if (this.TryGetRootVertex(out rootVertex))
                roots = new TVertex[] { rootVertex };
            else
                roots = AlgorithmExtensions.Roots(this.VisitedGraph);

            VisitRoots(roots);
        }

        public void Visit(TVertex s)
        {
            this.VisitRoots(new TVertex[] { s });
        }

        private void VisitRoots(IEnumerable<TVertex> roots)
        {
            // enqueue roots
            Parallel.ForEach<TVertex, TLocal>(
                roots,
                this.CreateLocal,
                (root, state, local) => this.EnqueueRoot(root, state, local),
                this.OnLocalFinalized
                );
            this.FlushVisitQueue();
        }

        private TLocal EnqueueRoot(TVertex s, ParallelLoopState state, TLocal local)
        {
            this.OnStartVertex(s, state, local);

            var color = (GraphColor)Interlocked.Exchange(
                ref this.vertexIndexedColors[this.vertexIndices[s]],
                (int)GraphColor.Gray);
            Contract.Assert(color == GraphColor.White);

            OnDiscoverVertex(s, state, local);
            this.vertexQueue.Enqueue(s);

            return local;
        }

        public event ParallelLocalEventHandler<TLocal> LocalCreated;
        private TLocal CreateLocal()
        {
            var local = new TLocal();

            var eh = this.LocalCreated;
            if (eh != null)
                eh(this, new ParallelLocalEventArgs<TLocal>(local));

            return local;
        }

        public event ParallelLocalEventHandler<TLocal> LocalFinalized;
        private void OnLocalFinalized(TLocal local)
        {
            var eh = this.LocalFinalized;
            if (eh != null)
                eh(this, new ParallelLocalEventArgs<TLocal>(local));
        }

        private void FlushVisitQueue()
        {
            var cancelManager = this.Services.CancelManager;

            while (this.vertexQueue.Count != 0)
            {
                if (cancelManager.IsCancelling) return;

                Parallel.For<TLocal>(
                    0,
                    this.vertexQueue.Count,
                    this.CreateLocal,
                    (i, state, local) => this.VisitLevel(state, local),
                    this.OnLocalFinalized
                    );
                this.OnNextLevel();
            }
        }

        private TLocal VisitLevel(ParallelLoopState state, TLocal local)
        {
            var u = this.vertexQueue.Dequeue();
            this.OnExamineVertex(u, state, local);

            Parallel.ForEach<TEdge, TLocal>(
                this.VisitedGraph.OutEdges(u),
                this.CreateLocal,
                (e, childState, childLocal) => this.VisitChildren(e, childState, childLocal),
                this.OnLocalFinalized
                );

            this.OnFinishVertex(u, state, local);
            return local;
        }

        private TLocal VisitChildren(TEdge e, ParallelLoopState state, TLocal local)
        {
            TVertex v = e.Target;
            OnExamineEdge(e, state, local);

            int vIndex = this.vertexIndices[v];
            var vColor = (GraphColor)Interlocked.CompareExchange(
                ref this.vertexIndexedColors[vIndex],
                (int)GraphColor.Gray,
                (int)GraphColor.White);
            if (vColor == GraphColor.White)
            {
                this.OnTreeEdge(e, state, local);
                this.OnDiscoverVertex(v, state, local);
                this.vertexQueue.Enqueue(v);
            }

            return local;
        }
    }
}
