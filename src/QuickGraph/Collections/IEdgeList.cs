using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace QuickGraph.Collections
{
    /// <summary>
    /// A cloneable list of edges
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    [ContractClass(typeof(IEdgeListContract<,>))]
    public interface IEdgeList<TVertex, TEdge>
        : IList<TEdge>
        #if !NETSTANDARD_PRE_2_0
        , ICloneable
        #endif
        where TEdge : IEdge<TVertex>
    {
        /// <summary>
        /// Trims excess allocated space
        /// </summary>
        void TrimExcess();
        /// <summary>
        /// Gets a clone of this list
        /// </summary>
        /// <returns></returns>
#if !NETSTANDARD_PRE_2_0
        new
#endif
        IEdgeList<TVertex, TEdge> Clone();
    }
}
