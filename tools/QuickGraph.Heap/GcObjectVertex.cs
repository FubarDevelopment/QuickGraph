using System;
using System.Globalization;

using QuickGraph.Heap.Data;

namespace QuickGraph.Heap
{
    public class GcObjectVertex
    {
        private readonly GcType type;
        private readonly long address;
        private readonly int size;
        private string kind;
        private readonly string value;
        private int gen;

        public GcObjectVertex(
            GcType type,
            long address,
            int size,
            string kind = null,
            int gen = -1,
            string value = null
            )
        {
            this.type = type;
            this.address = address;
            this.size = size;
            this.kind = kind;
            this.gen = gen;
            this.value = value;
        }

        public GcType Type
        {
            get { return this.type; }
        }

        public long Address
        {
            get { return this.address; }
        }

        public int Size
        {
            get { return this.size; }
        }

        public string Kind
        {
            get { return this.kind; }
            internal set { this.kind = value; }
        }

        public int Gen
        {
            get { return this.gen; }
            internal set { this.gen = value; }
        }

        public string Value
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            return String.Format("0x{0:x}-{1}-{2}",
                this.Address,
                this.Type.Name,
                this.Size
                );
        }
    }
}
