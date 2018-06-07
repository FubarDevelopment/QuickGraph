using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace QuickGraph.Contracts
{
    /// <summary>
    /// Debug only assertions and assumptions
    /// </summary>
    public static class GraphContract
    {
        [Pure]
        public static bool VertexCountEqual<TVertex>(
            this IVertexSet<TVertex> left,
            IVertexSet<TVertex> right)
        {
            Contract.Requires(left != null);
            Contract.Requires(right != null);

            return left.VertexCount == right.VertexCount;
        }

        [Pure]
        public static bool EdgeCountEqual<TVertex, TEdge>(
            this IEdgeListGraph<TVertex, TEdge> left,
            IEdgeListGraph<TVertex, TEdge> right)
            where TEdge : IEdge<TVertex>
        {
            Contract.Requires(left != null);
            Contract.Requires(right != null);

            return left.EdgeCount == right.EdgeCount;
        }

        [Pure]
        public static bool InVertexSet<TVertex>(
            this IVertexSet<TVertex> g,
            TVertex v)
        {
            Contract.Requires(g != null);
            Contract.Requires(v != null);
            // todo make requires
            return g.ContainsVertex(v);
        }

        [Pure]
        public static bool InVertexSet<TVertex, TEdge>(
            this IEdgeListGraph<TVertex, TEdge> g,
            TEdge e)
            where TEdge : IEdge<TVertex>
        {
            Contract.Requires(g != null);
            Contract.Requires(e != null);

            return InVertexSet<TVertex>(g, e.Source)
                && InVertexSet<TVertex>(g, e.Target);
        }

        [Pure]
        public static bool InEdgeSet<TVertex, TEdge>(
            this IEdgeListGraph<TVertex, TEdge> g,
            TEdge e)
            where TEdge : IEdge<TVertex>
        {
            Contract.Requires(g != null);
            Contract.Requires(e != null);

            return InVertexSet(g, e)
                && g.ContainsEdge(e);
        }
    }
}
