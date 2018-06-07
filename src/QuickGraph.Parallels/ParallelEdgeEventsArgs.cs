using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickGraph
{
    [Serializable]
    public class ParallelEdgeEventArgs<TVertex, TEdge, TLocal>
        : EdgeEventArgs<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        public ParallelEdgeEventArgs(TEdge edge, ParallelLoopState state, TLocal local)
            :base(edge)
        {
            State = state;
            Local = local;
        }

        public ParallelLoopState State { get; }

        public TLocal Local { get; }
    }

    public delegate void ParallelEdgeEventHandler<TVertex, TEdge, TLocal>(
        object sender,
        ParallelEdgeEventArgs<TVertex, TEdge, TLocal> args)
        where TEdge : IEdge<TVertex>;
}
