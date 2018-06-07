// <copyright file="ForestDisjointSetTTest.cs" company="Jonathan de Halleux">Copyright http://quickgraph.codeplex.com/</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph.Collections;
using System.Collections.Generic;

namespace QuickGraph.Collections
{
    /// <summary>This class contains parameterized unit tests for ForestDisjointSet`1</summary>
    [TestClass]
    [PexClass(typeof(ForestDisjointSet<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ForestDisjointSetTTest
    {
        [PexMethod(MaxConstraintSolverTime = 2)]
        public void Unions(int elementCount, [PexAssumeNotNull]KeyValuePair<int,int>[] unions)
        {
            PexAssume.IsTrue(0 < elementCount);
            PexSymbolicValue.Minimize(elementCount);
            PexAssertEx.TrueForAll(
                unions,
                u => 0 <= u.Key && u.Key < elementCount &&
                     0 <= u.Value && u.Value < elementCount
                     );

            var target = new ForestDisjointSet<int>();
            // fill up with 0..elementCount - 1
            for (int i = 0; i < elementCount; i++)
            {
                target.MakeSet(i);
                Assert.IsTrue(target.Contains(i));
                Assert.AreEqual(i + 1, target.ElementCount);
                Assert.AreEqual(i + 1, target.SetCount);
            }

            // apply Union for pairs unions[i], unions[i+1]
            for (int i = 0; i < unions.Length; i++)
            {
                var left = unions[i].Key;
                var right= unions[i].Value;

                var setCount = target.SetCount;
                bool unioned = target.Union(left, right);
                // should be in the same set now
                Assert.IsTrue(target.AreInSameSet(left, right));
                // if unioned, the count decreased by 1
                PexAssertEx.ImpliesIsTrue(unioned, () => setCount - 1 == target.SetCount);
            }
        }
    }
}
