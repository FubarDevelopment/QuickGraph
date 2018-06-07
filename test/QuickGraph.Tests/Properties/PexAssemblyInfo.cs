using System;

using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Validation;

[assembly: PexAssemblyUnderTest(typeof(QuickGraph.GraphColor))]
[assembly: PexAllowedExceptionFromAssembly(
    typeof(ArgumentException),
    "QuickGraph",
    AcceptExceptionSubtypes = true)]

[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
//[assembly: PexGenericArguments(typeof(int), typeof(Edge<int>))]
//[assembly: PexGenericArguments(typeof(int), typeof(SEdge<int>))]
