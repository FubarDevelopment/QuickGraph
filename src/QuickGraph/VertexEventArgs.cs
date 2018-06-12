using System;
using System.Diagnostics.Contracts;

namespace QuickGraph
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public abstract class VertexEventArgs<TVertex> : EventArgs
    {
        private readonly TVertex vertex;
        protected VertexEventArgs(TVertex vertex)
        {
            Contract.Requires(vertex != null);
            this.vertex = vertex;
        }

        public TVertex Vertex
        {
            get { return this.vertex; }
        }
    }

    public delegate void VertexAction<in TVertex>(TVertex vertex);

    public delegate void VertexEventHandler<TVertex>(
        Object sender,
        VertexEventArgs<TVertex> e);
}
