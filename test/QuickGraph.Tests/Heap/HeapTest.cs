using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QuickGraph.Heap;

namespace QuickGraph.Tests.Heap
{
    [TestClass]
    public partial class HeapTest
    {
        private GcTypeHeap LoadHeap()
        {
            GcTypeHeap heap = GcTypeHeap.Load(Path.Combine("Heap", "gcheap.xml"));
            return heap;
        }

        [TestMethod]
        public void Roots()
        {
            GcTypeHeap heap = this.LoadHeap();
            Console.WriteLine(heap.Roots);
        }

        [TestMethod]
        public void Types()
        {
            GcTypeHeap heap = this.LoadHeap();
            Console.WriteLine(heap.Types);
        }

        [TestMethod]
        public void Size()
        {
            GcTypeHeap heap = this.LoadHeap();
            Console.WriteLine(heap.Size);
        }

        [TestMethod]
        public void Touching()
        {
            GcTypeHeap heap = this.LoadHeap();
            Console.WriteLine(heap.Touching("Byte").Types);
        }

        [TestMethod]
        public void Merge()
        {
            GcTypeHeap heap = this.LoadHeap();
            Console.WriteLine(heap.Merge(1000).Types);
        }
    }
}
