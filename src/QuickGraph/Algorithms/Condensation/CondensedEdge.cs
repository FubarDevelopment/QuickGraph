﻿using System;
using System.Collections.Generic;
using QuickGraph.Collections;

namespace QuickGraph.Algorithms.Condensation
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public sealed class CondensedEdge<TVertex, TEdge, TGraph> : Edge<TGraph>
        where TEdge : IEdge<TVertex>
        where TGraph : IMutableVertexAndEdgeSet<TVertex, TEdge>, new()
    {
        private List<TEdge> edges = new List<TEdge>();
        public CondensedEdge(TGraph source, TGraph target)
            :base(source,target)
        { }

        public IList<TEdge> Edges
        {
            get { return this.edges; }
        }
    }
}
