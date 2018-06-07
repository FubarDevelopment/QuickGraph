#if !NETSTANDARD_PRE_2_0
using System;
using System.Collections.Generic;

namespace QuickGraph.Algorithms.Exploration
{
    public interface ITransitionFactory<TVertex,TEdge>
        where TVertex : ICloneable
        where TEdge : IEdge<TVertex>
    {
        bool IsValid(TVertex v);
        IEnumerable<TEdge> Apply(TVertex source);
    }
}
#endif
