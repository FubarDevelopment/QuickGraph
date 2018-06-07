using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickGraph
{
    [Serializable]
    public class ParallelVertexEventArgs<TVertex, TLocal>
        : VertexEventArgs<TVertex>
    {
        public ParallelVertexEventArgs(TVertex vertex, ParallelLoopState state, TLocal local)
            : base(vertex)
        {
            State = state;
            Local = local;
        }

        public ParallelLoopState State { get; }

        public TLocal Local { get; }
    }

    public delegate void ParallelVertexEventHandler<TVertex, TLocal>(
        object sender,
        ParallelVertexEventArgs<TVertex, TLocal> args)
    ;
}
