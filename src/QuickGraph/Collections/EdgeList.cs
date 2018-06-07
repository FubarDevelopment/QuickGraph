using System;
using System.Collections.Generic;
using System.Text;

namespace QuickGraph.Collections
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public sealed class EdgeList<TVertex, TEdge>
        : List<TEdge>
        , IEdgeList<TVertex, TEdge>
#if !NETSTANDARD_PRE_2_0
        , ICloneable
#endif
        where TEdge : IEdge<TVertex>
    {
        public EdgeList()
        { }

        public EdgeList(int capacity)
            : base(capacity)
        { }

        public EdgeList(EdgeList<TVertex, TEdge> list)
            : base(list)
        {}

        public EdgeList<TVertex, TEdge> Clone()
        {
            return new EdgeList<TVertex, TEdge>(this);
        }

        IEdgeList<TVertex, TEdge> IEdgeList<TVertex,TEdge>.Clone()
        {
            return this.Clone();
        }

#if !NETSTANDARD_PRE_2_0
        object ICloneable.Clone()
        {
            return this.Clone();
        }
#endif
    }
}
