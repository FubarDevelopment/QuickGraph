using System;

namespace QuickGraph
{
    /// <summary>
    /// Colors used in vertex coloring algorithms
    /// </summary>
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public enum GraphColor : byte
    {
        /// <summary>
        /// Usually initial color,
        /// </summary>
        White = 0,
        /// <summary>
        /// Usually intermidiate color,
        /// </summary>
        Gray,
        /// <summary>
        /// Usually finished color
        /// </summary>
        Black
    }
}
