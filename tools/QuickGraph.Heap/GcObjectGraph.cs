using System;
using System.Collections.Generic;
using System.Globalization;

namespace QuickGraph.Heap
{
    public sealed class GcObjectGraph :
        BidirectionalGraph<GcObjectVertex, Edge<GcObjectVertex>>
    {
        private readonly Dictionary<long, GcObjectVertex> addressObjects;
        private readonly List<GcObjectVertex> roots;

        public GcObjectGraph(int objectCount, int rootCount)
            : base(false, objectCount)
        {
            this.addressObjects = new Dictionary<long, GcObjectVertex>(objectCount);
            this.roots = new List<GcObjectVertex>(rootCount);
        }

        public ICollection<GcObjectVertex> Roots
        {
            get { return this.roots; }
        }

        public GcObjectVertex FromAddress(long address)
        {
            GcObjectVertex vertex;
            if (this.addressObjects.TryGetValue(address, out vertex))
                return vertex;
            else
                return null;
        }

        public GcObjectVertex AddVertex(
            GcType type,
            long address,
            int size
            )
        {
            GcObjectVertex v = new GcObjectVertex(
                    type,
                    address,
                    size);
            this.AddVertex(v);
            return v;
        }

        public override bool AddVertex(GcObjectVertex v)
        {
            if (!base.AddVertex(v))
                return false;
            this.addressObjects.Add(v.Address, v);
            return true;
        }

        public void SetAsRoot(GcRoot root)
        {
            GcObjectVertex v = this.FromAddress(root.Address);
            if (v != null)
            {
                v.Kind = root.Kind;
                this.roots.Add(v);
            }
        }

        public override bool RemoveVertex(GcObjectVertex v)
        {
            this.addressObjects.Remove(v.Address);
            return base.RemoveVertex(v);
        }
    }
}
