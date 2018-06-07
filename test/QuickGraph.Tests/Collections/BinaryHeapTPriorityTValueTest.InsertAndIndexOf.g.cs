// <copyright file="BinaryHeapTPriorityTValueTest.InsertAndIndexOf.g.cs" company="MSIT">Copyright © MSIT 2007</copyright>
// <auto-generated>
// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
// </auto-generated>
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace QuickGraph.Collections
{
    public partial class BinaryHeapTPriorityTValueTest
    {
[TestMethod]
[PexGeneratedBy(typeof(BinaryHeapTPriorityTValueTest))]
public void InsertAndIndexOf636()
{
    BinaryHeap<int, int> binaryHeap;
    binaryHeap = BinaryHeapFactory.Create(0);
    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[0];
    this.InsertAndIndexOf<int, int>(binaryHeap, keyValuePairs);
    Assert.IsNotNull((object)binaryHeap);
    Assert.IsNotNull(binaryHeap.PriorityComparison);
    Assert.AreEqual<int>(0, binaryHeap.Capacity);
    Assert.AreEqual<int>(0, binaryHeap.Count);
}
[TestMethod]
[PexGeneratedBy(typeof(BinaryHeapTPriorityTValueTest))]
public void InsertAndIndexOf471()
{
    BinaryHeap<int, int> binaryHeap;
    binaryHeap = BinaryHeapFactory.Create(1);
    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[1];
    this.InsertAndIndexOf<int, int>(binaryHeap, keyValuePairs);
    Assert.IsNotNull((object)binaryHeap);
    Assert.IsNotNull(binaryHeap.PriorityComparison);
    Assert.AreEqual<int>(1, binaryHeap.Capacity);
    Assert.AreEqual<int>(1, binaryHeap.Count);
}
[TestMethod]
[PexGeneratedBy(typeof(BinaryHeapTPriorityTValueTest))]
public void InsertAndIndexOf47101()
{
    BinaryHeap<int, int> binaryHeap;
    binaryHeap = BinaryHeapFactory.Create(0);
    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[1];
    this.InsertAndIndexOf<int, int>(binaryHeap, keyValuePairs);
    Assert.IsNotNull((object)binaryHeap);
    Assert.IsNotNull(binaryHeap.PriorityComparison);
    Assert.AreEqual<int>(1, binaryHeap.Capacity);
    Assert.AreEqual<int>(1, binaryHeap.Count);
}
[TestMethod]
[PexGeneratedBy(typeof(BinaryHeapTPriorityTValueTest))]
public void InsertAndIndexOf504()
{
    BinaryHeap<int, int> binaryHeap;
    binaryHeap = BinaryHeapFactory.Create(1);
    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[2];
    this.InsertAndIndexOf<int, int>(binaryHeap, keyValuePairs);
    Assert.IsNotNull((object)binaryHeap);
    Assert.IsNotNull(binaryHeap.PriorityComparison);
    Assert.AreEqual<int>(3, binaryHeap.Capacity);
    Assert.AreEqual<int>(2, binaryHeap.Count);
}
[TestMethod]
[PexGeneratedBy(typeof(BinaryHeapTPriorityTValueTest))]
public void InsertAndIndexOf50401()
{
    BinaryHeap<int, int> binaryHeap;
    binaryHeap = BinaryHeapFactory.Create(3);
    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[2];
    this.InsertAndIndexOf<int, int>(binaryHeap, keyValuePairs);
    Assert.IsNotNull((object)binaryHeap);
    Assert.IsNotNull(binaryHeap.PriorityComparison);
    Assert.AreEqual<int>(3, binaryHeap.Capacity);
    Assert.AreEqual<int>(2, binaryHeap.Count);
}
[TestMethod]
[PexGeneratedBy(typeof(BinaryHeapTPriorityTValueTest))]
public void InsertAndIndexOf332()
{
    BinaryHeap<int, int> binaryHeap;
    binaryHeap = BinaryHeapFactory.Create(2);
    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[3];
    KeyValuePair<int, int> s0 = new KeyValuePair<int, int>(1, default(int));
    keyValuePairs[1] = s0;
    KeyValuePair<int, int> s1 = new KeyValuePair<int, int>(int.MinValue, 1);
    keyValuePairs[2] = s1;
    this.InsertAndIndexOf<int, int>(binaryHeap, keyValuePairs);
    Assert.IsNotNull((object)binaryHeap);
    Assert.IsNotNull(binaryHeap.PriorityComparison);
    Assert.AreEqual<int>(5, binaryHeap.Capacity);
    Assert.AreEqual<int>(3, binaryHeap.Count);
}
    }
}
