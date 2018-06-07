namespace QuickGraph.Collections
{
    using System;
    using System.Collections.Generic;

#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public sealed class Queue<T> :
        System.Collections.Generic.Queue<T>,
        IQueue<T>
    {
    }
}
