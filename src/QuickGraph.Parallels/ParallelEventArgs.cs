using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickGraph
{
    public class ParallelEventArgs<TLocal>
        : EventArgs
    {
        readonly ParallelLoopState local;
        public ParallelEventArgs(ParallelLoopState local)
        {
            this.local = local;
        }

        public ParallelLoopState Local
        {
            get { return this.local; }
        }
    }

    public delegate void ParallelEventHandler<TLocal>(
        object sender,
        ParallelEventArgs<TLocal> local);
}
