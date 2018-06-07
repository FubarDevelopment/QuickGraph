using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph.Serialization;
using QuickGraph.Algorithms.TopologicalSort;

namespace QuickGraph.Algorithms
{
    [TestClass, PexClass]
    public partial class UndirectedFirstTopologicalSortAlgorithmTest
    {
        [TestMethod]
        [TestCategory(TestCategories.LongRunning)]
        public void UndirectedFirstTopologicalSortAll()
        {
            TestGraphFactory.GetUndirectedGraphs()
                .AsParallel()
                .ForAll(Compute);
        }

        [PexMethod]
        public void Compute<TVertex, TEdge>([PexAssumeNotNull]IUndirectedGraph<TVertex, TEdge> g)
            where TEdge : IEdge<TVertex>
        {
            var topo =
                new UndirectedFirstTopologicalSortAlgorithm<TVertex, TEdge>(g);
            topo.AllowCyclicGraph = true;
            topo.Compute();
        }

    }
}
