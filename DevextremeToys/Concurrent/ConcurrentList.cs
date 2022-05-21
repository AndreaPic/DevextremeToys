using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevExtremeToys.Concurrent
{
    /// <summary>
    /// Represents a thread safe and strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class ConcurrentList<T>  : IList<T> ,IEnumerable<T>, IEnumerable
    {
        /// <summary>
        /// List that contains elements
        /// </summary>
        private readonly List<T> list = new List<T>();
        
        /// <summary>
        /// Revision used to check for modified content
        /// </summary>
        private int revision = 0;

        /// <summary>
        /// Revision used to check for modified content
        /// </summary>
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

        /// <summary>
        /// Update object's revision
        /// </summary>
        private void RevisionIncrement()
        {
            lock (SyncRoot)
            {
                revision++;
            }
        }

        /// <summary>
        /// Object used for thread synchronization
        /// </summary>
        private readonly object SyncRoot = new object();

        /// <summary>
        /// Gets a value indicating whether the IList has a fixed size.
        /// </summary>
        public bool IsFixedSize => false;

        /// <summary>
        /// Gets a value indicating whether the ICollection<T> is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets the number of elements contained in the ICollection<T>.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>Element at the specified index</returns>
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

        /// <summary>
        /// Returns an enumerator that iterates through the List<T>.
        /// </summary>
        /// <returns>ConcurrentListEnumerator<T> Enumerator</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new ConcurrentListEnumerator<T>(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the List<T>.
        /// </summary>
        /// <returns>ConcurrentListEnumerator<T> Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ConcurrentListEnumerator<T>(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the List<T>.
        /// </summary>
        /// <returns>ConcurrentListEnumerator<T> Enumerator</returns>
        public ConcurrentListEnumerator<T> GetEnumerator()
        {
            return new ConcurrentListEnumerator<T>(this);
        }

        /// <summary>
        /// Adds an object to the end of the List<T>.
        /// </summary>
        /// <param name="value">The object to be added to the end of the List<T>. The value can be null for reference types.</param>
        public void Add(T value)
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.Add(value);
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the List<T>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List<T>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.AddRange(collection);
            }
        }


        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire List<T>.
        /// </summary>
        /// <param name="item">The object to locate in the List<T>. The value can be null for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire List<T>, if found; otherwise, -1.</returns>
        public int IndexOf(T item)
        {
            lock (SyncRoot)
            {
                return list.IndexOf(item);
            }
        }

        /// <summary>
        /// Inserts an item to the IList<T> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the IList<T>.</param>
        public void Insert(int index, T item)
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.Insert(index, item);
            }
        }

        /// <summary>
        /// Removes the IList<T> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.RemoveAt(index);
            }
        }

        /// <summary>
        /// Removes all elements from the List<T>.
        /// </summary>
        public void Clear()
        {
            lock (SyncRoot)
            {
                RevisionIncrement();
                list.Clear();
            }
        }

        /// <summary>
        /// Determines whether an element is in the List<T>.
        /// </summary>
        /// <param name="item">The object to locate in the List<T>. The value can be null for reference types.</param>
        /// <returns>true if item is found in the List<T>; otherwise, false.</returns>
        public bool Contains(T item)
        {
            lock (SyncRoot)
            {
                return list.Contains(item);
            }
        }

        /// <summary>
        /// Copies the List<T> or a portion of it to an array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List<T>. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (SyncRoot)
            {
                list.CopyTo(array,arrayIndex);
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the List<T>.
        /// </summary>
        /// <param name="item">The object to remove from the List<T>. The value can be null for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the List<T>.</returns>
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

    /// <summary>
    /// ConcurrentList Enumeraor
    /// </summary>
    /// <typeparam name="T">The type of objects to enumerate.</typeparam>
    public class ConcurrentListEnumerator<T> : IEnumerator, IEnumerator<T>
    {
        /// <summary>
        /// Enumerating list
        /// </summary>
        private readonly ConcurrentList<T> list;
        /// <summary>
        /// Enumerating current index 
        /// </summary>
        private int index;
        /// <summary>
        /// Initial version of the enumerating list
        /// </summary>
        private int revision;

        /// <summary>
        /// Initialize enumerator
        /// </summary>
        public void Reset()
        {
            Interlocked.Exchange(ref index, -1);
            Interlocked.Exchange(ref revision, list.Revision);
        }

        /// <summary>
        /// Create enumerator instance
        /// </summary>
        /// <param name="list">Enumerating List</param>
        internal ConcurrentListEnumerator(ConcurrentList<T> list)
        {
            this.list = list;
            Reset();
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
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

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
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

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {            
        }
    }
}

