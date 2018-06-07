using System;

namespace QuickGraph
{
#if !NETSTANDARD_PRE_2_0
    [System.Serializable]
#endif
    public class NegativeWeightException
        : QuickGraphException
    {
        public NegativeWeightException() { }
        public NegativeWeightException(string message) : base(message) { }
        public NegativeWeightException(string message, Exception inner) : base(message, inner) { }
#if !NETSTANDARD_PRE_2_0
        protected NegativeWeightException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
#endif
    }
}
