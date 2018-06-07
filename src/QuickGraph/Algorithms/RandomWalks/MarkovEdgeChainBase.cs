using System;
using System.Collections.Generic;

namespace QuickGraph.Algorithms.RandomWalks
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public abstract class MarkovEdgeChainBase<TVertex, TEdge> :
        IMarkovEdgeChain<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        private Random rand = new Random();

        public Random Rand
        {
            get
            {
                return this.rand;
            }
            set
            {
                this.rand = value;
            }
        }

        public abstract bool TryGetSuccessor(IImplicitGraph<TVertex, TEdge> g, TVertex u, out TEdge successor);
        public abstract bool TryGetSuccessor(IEnumerable<TEdge> edges, TVertex u, out TEdge successor);
    }
}
