using System;

namespace QuickGraph
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public class NonAcyclicGraphException
        : QuickGraphException
    {
        public NonAcyclicGraphException() { }
        public NonAcyclicGraphException(string message) : base( message ) { }
        public NonAcyclicGraphException(string message, System.Exception inner) : base( message, inner ) { }
#if !NETSTANDARD_PRE_2_0
        protected NonAcyclicGraphException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base( info, context ) { }
#endif
    }
}


