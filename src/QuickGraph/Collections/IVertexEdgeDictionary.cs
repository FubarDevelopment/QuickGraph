using System;
using System.Collections.Generic;
#if !NETSTANDARD_PRE_2_0
using System.Runtime.Serialization;
#endif
using System.Diagnostics.Contracts;

namespace QuickGraph.Collections
{
    /// <summary>
    /// A dictionary of vertices to a list of edges
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    [ContractClass(typeof(IVertexEdgeDictionaryContract<,>))]
    public interface IVertexEdgeDictionary<TVertex, TEdge>
        : IDictionary<TVertex, IEdgeList<TVertex, TEdge>>
#if !NETSTANDARD_PRE_2_0
        , ICloneable
        , ISerializable
#endif
     where TEdge : IEdge<TVertex>
    {
        /// <summary>
        /// Gets a clone of the dictionary. The vertices and edges are not cloned.
        /// </summary>
        /// <returns></returns>
#if !NETSTANDARD_PRE_2_0
        new
#endif
        IVertexEdgeDictionary<TVertex, TEdge> Clone();
    }
}
