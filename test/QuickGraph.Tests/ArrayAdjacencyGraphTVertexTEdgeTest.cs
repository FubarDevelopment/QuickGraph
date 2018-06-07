// <copyright file="ArrayAdjacencyGraphTVertexTEdgeTest.cs" company="Jonathan de Halleux">Copyright http://quickgraph.codeplex.com/</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph;
using QuickGraph.Serialization;

namespace QuickGraph
{
    /// <summary>This class contains parameterized unit tests for ArrayAdjacencyGraph`2</summary>
    [PexClass(typeof(ArrayAdjacencyGraph<, >))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    [PexGenericArguments(typeof(int), typeof(SEdge<int>))]
    public partial class ArrayAdjacencyGraphTVertexTEdgeTest
    {
        [TestMethod]
        public void SameVertexCountAll()
        {
            foreach (var g in TestGraphFactory.GetAdjacencyGraphs())
                this.SameVertexCount(g);
        }

        [PexMethod]
        public void SameVertexCount<TVertex, TEdge>([PexAssumeNotNull]IVertexAndEdgeListGraph<TVertex, TEdge> g)
            where TEdge : IEdge<TVertex>
        {
            var ag = GraphExtensions.ToArrayAdjacencyGraph(g);
            Assert.AreEqual(g.VertexCount, ag.VertexCount);
        }

        [TestMethod]
        public void SameVerticesAll()
        {
            foreach (var g in TestGraphFactory.GetAdjacencyGraphs())
                this.SameVertices(g);
        }

        [PexMethod]
        public void SameVertices<TVertex, TEdge>([PexAssumeNotNull]IVertexAndEdgeListGraph<TVertex, TEdge> g)
            where TEdge : IEdge<TVertex>
        {
            var ag = GraphExtensions.ToArrayAdjacencyGraph(g);
            PexAssertEx.AreElementsEqual(g.Vertices, ag.Vertices, (l, r) => l.Equals(r));
        }

        [TestMethod]
        public void SameEdgeCountAll()
        {
            foreach (var g in TestGraphFactory.GetAdjacencyGraphs())
                this.SameEdgeCount(g);
        }

        [PexMethod]
        public void SameEdgeCount<TVertex, TEdge>([PexAssumeNotNull]IVertexAndEdgeListGraph<TVertex, TEdge> g)
            where TEdge : IEdge<TVertex>
        {
            var ag = GraphExtensions.ToArrayAdjacencyGraph(g);
            Assert.AreEqual(g.EdgeCount, ag.EdgeCount);
        }

        [TestMethod]
        public void SameEdgesAll()
        {
            foreach (var g in TestGraphFactory.GetAdjacencyGraphs())
                this.SameEdges(g);
        }

        [PexMethod]
        public void SameEdges<TVertex, TEdge>([PexAssumeNotNull]IVertexAndEdgeListGraph<TVertex, TEdge> g)
            where TEdge : IEdge<TVertex>
        {
            var ag = GraphExtensions.ToArrayAdjacencyGraph(g);
            PexAssertEx.AreElementsEqual(g.Edges, ag.Edges, (l, r) => l.Equals(r));
        }

        [TestMethod]
        public void SameOutEdgesAll()
        {
            foreach (var g in TestGraphFactory.GetAdjacencyGraphs())
                this.SameOutEdges(g);
        }

        [PexMethod]
        public void SameOutEdges<TVertex, TEdge>([PexAssumeNotNull]IVertexAndEdgeListGraph<TVertex, TEdge> g)
            where TEdge : IEdge<TVertex>
        {
            var ag = GraphExtensions.ToArrayAdjacencyGraph(g);
            foreach(var v in g.Vertices)
                PexAssertEx.AreElementsEqual(g.OutEdges(v), ag.OutEdges(v), (l, r) => l.Equals(r));
        }

        /// <summary>Test stub for AllowParallelEdges</summary>
        [PexMethod]
        public void AllowParallelEdgesGet<TVertex,TEdge>([PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.AllowParallelEdgesGet(ArrayAdjacencyGraph`2<!!0,!!1>)
            bool result = target.AllowParallelEdges;
        }

        /// <summary>Test stub for ContainsEdge(!0, !0)</summary>
        [PexMethod]
        public bool ContainsEdge<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target01,
            TVertex source,
            TVertex target
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.ContainsEdge(ArrayAdjacencyGraph`2<!!0,!!1>, !!0, !!0)
            bool result = target01.ContainsEdge(source, target);
            return result;
        }

        /// <summary>Test stub for ContainsEdge(!1)</summary>
        [PexMethod]
        public bool ContainsEdge01<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target,
            TEdge edge
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.ContainsEdge01(ArrayAdjacencyGraph`2<!!0,!!1>, !!1)
            bool result = target.ContainsEdge(edge);
            return result;
        }

        /// <summary>Test stub for ContainsVertex(!0)</summary>
        [PexMethod]
        public bool ContainsVertex<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target,
            TVertex vertex
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.ContainsVertex(ArrayAdjacencyGraph`2<!!0,!!1>, !!0)
            bool result = target.ContainsVertex(vertex);
            return result;
        }

        /// <summary>Test stub for EdgeCount</summary>
        [PexMethod]
        public void EdgeCountGet<TVertex,TEdge>([PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.EdgeCountGet(ArrayAdjacencyGraph`2<!!0,!!1>)
            int result = target.EdgeCount;
        }

        /// <summary>Test stub for Edges</summary>
        [PexMethod]
        public void EdgesGet<TVertex,TEdge>([PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.EdgesGet(ArrayAdjacencyGraph`2<!!0,!!1>)
            IEnumerable<TEdge> result = target.Edges;
        }

        /// <summary>Test stub for IsDirected</summary>
        [PexMethod]
        public void IsDirectedGet<TVertex,TEdge>([PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.IsDirectedGet(ArrayAdjacencyGraph`2<!!0,!!1>)
            bool result = target.IsDirected;
        }

        /// <summary>Test stub for IsEdgesEmpty</summary>
        [PexMethod]
        public void IsEdgesEmptyGet<TVertex,TEdge>([PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.IsEdgesEmptyGet(ArrayAdjacencyGraph`2<!!0,!!1>)
            bool result = target.IsEdgesEmpty;
        }

        /// <summary>Test stub for IsOutEdgesEmpty(!0)</summary>
        [PexMethod]
        public bool IsOutEdgesEmpty<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target,
            TVertex v
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.IsOutEdgesEmpty(ArrayAdjacencyGraph`2<!!0,!!1>, !!0)
            bool result = target.IsOutEdgesEmpty(v);
            return result;
        }

        /// <summary>Test stub for IsVerticesEmpty</summary>
        [PexMethod]
        public void IsVerticesEmptyGet<TVertex,TEdge>([PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.IsVerticesEmptyGet(ArrayAdjacencyGraph`2<!!0,!!1>)
            bool result = target.IsVerticesEmpty;
        }

        /// <summary>Test stub for OutDegree(!0)</summary>
        [PexMethod]
        public int OutDegree<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target,
            TVertex v
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.OutDegree(ArrayAdjacencyGraph`2<!!0,!!1>, !!0)
            int result = target.OutDegree(v);
            return result;
        }

        /// <summary>Test stub for OutEdge(!0, Int32)</summary>
        [PexMethod]
        public TEdge OutEdge<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target,
            TVertex v,
            int index
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.OutEdge(ArrayAdjacencyGraph`2<!!0,!!1>, !!0, Int32)
            TEdge result = target.OutEdge(v, index);
            return result;
        }

        /// <summary>Test stub for OutEdges(!0)</summary>
        [PexMethod]
        public IEnumerable<TEdge> OutEdges<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target,
            TVertex v
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.OutEdges(ArrayAdjacencyGraph`2<!!0,!!1>, !!0)
            IEnumerable<TEdge> result = target.OutEdges(v);
            return result;
        }

        /// <summary>Test stub for TryGetEdge(!0, !0, !1&amp;)</summary>
        [PexMethod]
        public bool TryGetEdge<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target01,
            TVertex source,
            TVertex target,
            out TEdge edge
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.TryGetEdge(ArrayAdjacencyGraph`2<!!0,!!1>, !!0, !!0, !!1&)
            bool result = target01.TryGetEdge(source, target, out edge);
            return result;
        }

        /// <summary>Test stub for TryGetEdges(!0, !0, IEnumerable`1&lt;!1&gt;&amp;)</summary>
        [PexMethod]
        public bool TryGetEdges<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target01,
            TVertex source,
            TVertex target,
            out IEnumerable<TEdge> edges
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.TryGetEdges(ArrayAdjacencyGraph`2<!!0,!!1>, !!0, !!0, IEnumerable`1<!!1>&)
            bool result = target01.TryGetEdges(source, target, out edges);
            return result;
        }

        /// <summary>Test stub for TryGetOutEdges(!0, IEnumerable`1&lt;!1&gt;&amp;)</summary>
        [PexMethod]
        public bool TryGetOutEdges<TVertex,TEdge>(
            [PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target,
            TVertex v,
            out IEnumerable<TEdge> edges
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.TryGetOutEdges(ArrayAdjacencyGraph`2<!!0,!!1>, !!0, IEnumerable`1<!!1>&)
            bool result = target.TryGetOutEdges(v, out edges);
            return result;
        }

        /// <summary>Test stub for VertexCount</summary>
        [PexMethod]
        public void VertexCountGet<TVertex,TEdge>([PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.VertexCountGet(ArrayAdjacencyGraph`2<!!0,!!1>)
            int result = target.VertexCount;
        }

        /// <summary>Test stub for Vertices</summary>
        [PexMethod]
        public void VerticesGet<TVertex,TEdge>([PexAssumeUnderTest]ArrayAdjacencyGraph<TVertex, TEdge> target)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method ArrayAdjacencyGraphTVertexTEdgeTest.VerticesGet(ArrayAdjacencyGraph`2<!!0,!!1>)
            IEnumerable<TVertex> result = target.Vertices;
        }
    }
}
