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
    public class EdgeEdgeDictionary<TVertex, TEdge>
        : Dictionary<TEdge, TEdge>
#if !NETSTANDARD_PRE_2_0
        , ICloneable
        , ISerializable
#endif
        where TEdge : IEdge<TVertex>
    {
        public EdgeEdgeDictionary()
        { }

        public EdgeEdgeDictionary(int capacity)
            : base(capacity)
        { }

#if !NETSTANDARD_PRE_2_0
        protected EdgeEdgeDictionary(
            SerializationInfo info, StreamingContext context)
            : base(info, context) { }
#endif

        public EdgeEdgeDictionary<TVertex, TEdge> Clone()
        {
            var clone = new EdgeEdgeDictionary<TVertex, TEdge>(this.Count);
            foreach (var kv in this)
                clone.Add(kv.Key, kv.Value);
            return clone;
        }

#if !NETSTANDARD_PRE_2_0
        object ICloneable.Clone()
        {
            return this.Clone();
        }
#endif
    }
}
