using System;
using System.Collections.Generic;
using System.Text;
#if !NETSTANDARD_PRE_2_0
using System.Runtime.Serialization;
#endif

namespace QuickGraph.Collections
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public sealed class VertexList<TVertex>
        : List<TVertex>
#if !NETSTANDARD_PRE_2_0
        , ICloneable
#endif
    {
        public VertexList()
        { }

        public VertexList(int capacity)
            : base(capacity)
        { }

        public VertexList(VertexList<TVertex> other)
            : base(other)
        { }

        public VertexList<TVertex> Clone()
        {
            return new VertexList<TVertex>(this);
        }

#if !NETSTANDARD_PRE_2_0
        object ICloneable.Clone()
        {
            return this.Clone();
        }
#endif
    }
}
