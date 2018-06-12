﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Linq;

namespace QuickGraph.Collections
{
    /// <summary>
    /// Binary heap
    /// </summary>
    /// <remarks>
    /// Indexing rules:
    ///
    /// parent index: index ¡ 1)/2
    /// left child: 2 * index + 1
    /// right child: 2 * index + 2
    ///
    /// Reference:
    /// http://dotnetslackers.com/Community/files/folders/data-structures-and-algorithms/entry28722.aspx
    /// </remarks>
    /// <typeparam name="TValue">type of the value</typeparam>
    /// <typeparam name="TPriority">type of the priority metric</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class BinaryHeap<TPriority, TValue>
        : IEnumerable<KeyValuePair<TPriority, TValue>>
    {
        readonly Comparison<TPriority> priorityComparison;
        KeyValuePair<TPriority, TValue>[] items;
        int count;
        int version;

        const int DefaultCapacity = 16;

        public BinaryHeap()
            : this(DefaultCapacity, Comparer<TPriority>.Default.Compare)
        { }

        public BinaryHeap(Comparison<TPriority> priorityComparison)
            : this(DefaultCapacity, priorityComparison)
        { }

        public BinaryHeap(int capacity, Comparison<TPriority> priorityComparison)
        {
            Contract.Requires(capacity >= 0);
            Contract.Requires(priorityComparison != null);

            this.items = new KeyValuePair<TPriority, TValue>[capacity];
            this.priorityComparison = priorityComparison;
        }

        public Comparison<TPriority> PriorityComparison
        {
            get { return this.priorityComparison; }
        }

        public int Capacity
        {
            get { return this.items.Length; }
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(TPriority priority, TValue value)
        {
            this.version++;
            this.ResizeArray();
            this.items[this.count++] = new KeyValuePair<TPriority, TValue>(priority, value);
            this.MinHeapifyDown(this.count - 1);
        }

        // TODO: MinHeapifyDown is really MinHeapifyUp.  Do the renaming
        private void MinHeapifyDown(int start)
        {
            int current = start;
            int parent = (current - 1) / 2;
            while (current > 0 && this.Less(current, parent))
            {
                this.Swap(current, parent);
                current = parent;
                parent = (current - 1) / 2;
            }
        }

        public TValue[] ToValueArray()
        {
            var values = new TValue[this.items.Length];
            for (int i = 0; i < values.Length; ++i)
                values[i] = this.items[i].Value;
            return values;
        }

        public KeyValuePair<TPriority, TValue>[] ToPriorityValueArray()
        {
            var array = new KeyValuePair<TPriority, TValue>[this.items.Length];
            for (int i = 0; i < array.Length; ++i)
                array[i] = this.items[i];
            return array;
        }

        public bool IsConsistent()
        {
            int wrong = -1;

            for (int i = 0; i < this.count; i++)
            {
                var l = 2 * i + 1;
                var r = 2 * i + 2;
                if (l < this.count && !this.LessOrEqual(i, l))
                    wrong = i;
                if (r < this.count && !this.LessOrEqual(i, r))
                    wrong = i;
            }

            var correct = wrong == -1;
            return correct;
        }

        private string EntryToString(int i)
        {
            if (i < 0 || i >= this.count)
                return "null";

            var kvp = this.items[i];
            var k = kvp.Key;
            var v = kvp.Value;

            var str = "";
            str += k.ToString();
            str += " ";
            str += v == null ? "null" : v.ToString();
            return str;
        }

        public string ToString2()
        {
            var status = IsConsistent();
            var str = status.ToString() + ": ";

            for (int i = 0; i < this.items.Length; i++)
            {
                str += EntryToString(i);
                str += ", ";
            }
            return str;
        }

        public string ToStringTree()
        {
            var status = IsConsistent();
            var str = "Consistent? " + status.ToString();

            for (int i = 0; i < this.count; i++)
            {
                var l = 2 * i + 1;
                var r = 2 * i + 2;

                var s = "index";
                s += i.ToString();
                s += ": ";
                s += EntryToString(i);
                s += " -> ";
                s += EntryToString(l);
                s += " and ";
                s += EntryToString(r);

                str += "\r\n" + s;
            }
            return str;
        }

        private void ResizeArray()
        {
            if (this.count == this.items.Length)
            {
                var newItems = new KeyValuePair<TPriority, TValue>[this.count * 2 + 1];
                Array.Copy(this.items, newItems, this.count);
                this.items = newItems;
            }
        }

        public KeyValuePair<TPriority, TValue> Minimum()
        {
            if (this.count == 0)
                throw new InvalidOperationException();
            return this.items[0];
        }

        public KeyValuePair<TPriority, TValue> RemoveMinimum()
        {
            if (this.count == 0)
                throw new InvalidOperationException("heap is empty");

            // shortcut for heap with 1 element.
            if (this.count == 1)
            {
                this.version++;
                return this.items[--this.count];
            }
            this.Swap(0, this.count - 1);
            this.count--;
            this.MinHeapifyUp(0);
            return this.items[this.count];
        }

        /// <summary>
        /// Removes element at a certain index.
        /// TODO: RemoveAt is wrong.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [Obsolete("BinaryHeap.RemoveAt is wrong. Fix it before using it.")]
        public KeyValuePair<TPriority, TValue> RemoveAt(int index)
        {
            if (this.count == 0)
                throw new InvalidOperationException("heap is empty");
            if (index < 0 || index >= this.count)
                throw new ArgumentOutOfRangeException("index");

            this.version++;
            // shortcut for heap with 1 element.
            if (this.count == 1)
                return this.items[--this.count];

            this.Swap(index, this.count - 1);
            this.count--;
            this.MinHeapifyUp(index);

            return this.items[this.count];
        }

        // TODO: MinHeapifyUp is really MinHeapifyDown.  Do the renaming
        private void MinHeapifyUp(int index)
        {
            while (true)
            {
                var left = 2 * index + 1;
                var right = 2 * index + 2;
                var smallest = index;
                if (left < this.count && this.Less(left, smallest))
                    smallest = left;
                if (right < this.count && this.Less(right, smallest))
                    smallest = right;

                if (smallest == index)
                    break;

                this.Swap(smallest, index);
                index = smallest;
            }
        }

        public int IndexOf(TValue value)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (object.Equals(value, this.items[i].Value))
                    return i;
            }
            return -1;
        }

        public bool MinimumUpdate(TPriority priority, TValue value)
        {
            // find index
            var index = IndexOf(value);

            if (index >= 0)
            {
                if (this.priorityComparison(priority, this.items[index].Key) <= 0)
                {
                    this.Update(priority, value);
                    return true;
                }
                return false;
            }

            // not in collection
            this.Add(priority, value);
            return true;
        }

        public void Update(TPriority priority, TValue value)
        {
            // find index
            var index = this.IndexOf(value);

            // if it exists, update, else add
            if (index > -1)
            {
                var neww = priority;
                var oldd = this.items[index].Key;
                this.items[index] = new KeyValuePair<TPriority,TValue>(neww, value);

                if (this.priorityComparison(neww, oldd) > 0)
                    MinHeapifyUp(index);
                else if (this.priorityComparison(neww, oldd) < 0)
                    MinHeapifyDown(index);
            }
            else
            {
            this.Add(priority, value);
        }
        }

        [Pure]
        private bool LessOrEqual(int i, int j)
        {
            Contract.Requires(
                i >= 0 & i < this.count &
                j >= 0 & j < this.count &
                i != j);

            return this.priorityComparison(this.items[i].Key, this.items[j].Key) <= 0;
        }

        [Pure]
        private bool Less(int i, int j)
        {
            Contract.Requires(
                i >= 0 & i < this.count &
                j >= 0 & j < this.count);

            return this.priorityComparison(this.items[i].Key, this.items[j].Key) < 0;
        }

        private void Swap(int i, int j)
        {
            Contract.Requires(
                i >= 0 && i < this.count &&
                j >= 0 && j < this.count);

            if (i == j)
            {
                return;
            }

            var kv = this.items[i];
            this.items[i] = this.items[j];
            this.items[j] = kv;
        }

#if DEEP_INVARIANT
        [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(this.items != null);
            Contract.Invariant(
                this.count > -1 &
                this.count <= this.items.Length);
            Contract.Invariant(
                EnumerableContract.All(0, this.count, index =>
                {
                    var left = 2 * index + 1;
                    var right = 2 * index + 2;
                    return  (left >= count || this.LessOrEqual(index, left)) &&
                            (right >= count || this.LessOrEqual(index, right));
                })
            );
        }
#endif

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members
        public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
        {
            return new Enumerator(this);
        }

        struct Enumerator :
            IEnumerator<KeyValuePair<TPriority, TValue>>
        {
            BinaryHeap<TPriority, TValue> owner;
            KeyValuePair<TPriority, TValue>[] items;
            readonly int count;
            readonly int version;
            int index;

            public Enumerator(BinaryHeap<TPriority, TValue> owner)
            {
                this.owner = owner;
                this.items = owner.items;
                this.count = owner.count;
                this.version = owner.version;
                this.index = -1;
            }

            public KeyValuePair<TPriority, TValue> Current
            {
                get
                {
                    if (this.version != this.owner.version)
                        throw new InvalidOperationException();
                    if (this.index < 0 | this.index == this.count)
                        throw new InvalidOperationException();
                    Contract.Assert(this.index <= this.count);
                    return this.items[this.index];
                }
            }

            void IDisposable.Dispose()
            {
                this.owner = null;
                this.items = null;
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                if (this.version != this.owner.version)
                    throw new InvalidOperationException();
                return ++this.index < this.count;
            }

            public void Reset()
            {
                if (this.version != this.owner.version)
                    throw new InvalidOperationException();
                this.index = -1;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

    }
}
