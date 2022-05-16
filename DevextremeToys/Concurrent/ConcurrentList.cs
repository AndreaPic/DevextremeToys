using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.Concurrent
{
    public class ConcurrentList<T>  : IList<T> ,IEnumerable<T>, IEnumerable
    {
        private readonly List<T> list = new List<T>();
        
        private int revision = 0;

        internal int Revision
        {
            get 
            {
                lock (SyncRoot)
                {
                    return revision;
                }
            }
        }

        private void RevisionIncrement()
        {
            lock (SyncRoot)
            {
                revision++;
            }
        }


        private readonly object SyncRoot = new object();

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Count
        {
            get
            {
                lock (SyncRoot)
                {
                    return list.Count;
                }
            }
        }

        public T this[int index] 
        { 
            get
            {
                return list[index];
            }
            set
            {
                lock (SyncRoot)
                {
                    RevisionIncrement();
                    list[index] = value;
                }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new ConcurrentListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ConcurrentListEnumerator<T>(this);
        }

        public ConcurrentListEnumerator<T> GetEnumerator()
        {
            return new ConcurrentListEnumerator<T>(this);
        }


        public void Add(T value)
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.Add(value);
            }
        }

        public int IndexOf(T item)
        {
            lock (SyncRoot)
            {
                return list.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.Insert(index, item);
            }
        }

        public void RemoveAt(int index)
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.RemoveAt(index);
            }
        }

        public void Clear()
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.Clear();
            }
        }

        public bool Contains(T item)
        {
            lock (SyncRoot)
            {
                return list.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (SyncRoot)
            {
                list.CopyTo(array,arrayIndex);
            }
        }

        public bool Remove(T item)
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                bool ret = list.Remove(item);  
                return ret;
            }
        }
    }

    public class ConcurrentListEnumerator<T> : IEnumerator, IEnumerator<T>
    {
        private readonly ConcurrentList<T> list;
        private int index;
        private int revision;

        public void Reset()
        {
            Interlocked.Exchange(ref index, -1);
            revision = list.Revision;
        }
        internal ConcurrentListEnumerator(ConcurrentList<T> list)
        {
            this.list = list;
            Reset();
        }

        object IEnumerator.Current
        {
            get
            {
                if (revision != list.Revision)
                {
                    throw new InvalidOperationException("Collection modified while enumerating.");
                }
                return list[index];
            }
        }

        public T Current
        {
            get
            {
                if (revision != list.Revision)
                {
                    throw new InvalidOperationException("Collection modified while enumerating.");
                }
                return list[index];
            }
        }

        public bool MoveNext()
        {
            Interlocked.Increment(ref index);
            if (index >= list.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        void IDisposable.Dispose()
        {            
        }
    }
}
