using System;
using System.Collections.Generic;
using System.Text;

namespace QuickGraph
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public class NegativeCycleGraphException
        : QuickGraphException
    {
        public NegativeCycleGraphException() { }
        public NegativeCycleGraphException(string message) : base(message) { }
        public NegativeCycleGraphException(string message, Exception inner) : base(message, inner) { }
#if !NETSTANDARD_PRE_2_0
        protected NegativeCycleGraphException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
#endif
    }
}
