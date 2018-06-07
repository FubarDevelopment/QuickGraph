using System;

namespace QuickGraph
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public abstract class QuickGraphException
        : Exception
    {
        protected QuickGraphException() { }
        protected QuickGraphException(string message) : base(message) { }
        protected QuickGraphException(string message, Exception inner) : base(message, inner) { }
#if !NETSTANDARD_PRE_2_0
        protected QuickGraphException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
#endif
    }
}
