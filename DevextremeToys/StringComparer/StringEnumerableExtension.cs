using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevExtremeToys.StringComparer
{
    /// <summary>
    /// Extension methods to compare strings inside list
    /// </summary>
    public static class StringEnumerableExtension
    {

        /// <summary>
        /// Determines whether an element is in the enumerable
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The string to locate in the enumerable
        /// </param>
        /// <returns>
        //     true if item is found ; otherwise, false.
        /// </returns>
        public static bool ContainsDevEx(this IEnumerable<string> source, string value)
        {
            return Contains(source, value);
        }

        /// <summary>
        //     Searches for the specified object and returns the zero-based index of the first
        //     occurrence within the entire enumerable.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to locate in the enumerable
        /// </param>
        /// <returns>
        //     The zero-based index of the first occurrence of item within the entire enumerable
        //     if found; otherwise, -1.
        /// </returns>
        public static int IndexOfDevEx(this IEnumerable<string> source, string value)
        {
            return IndexOf(source, value, 0, GetCount(source));
        }

        /// <summary>
        //     Searches for the specified object and returns the zero-based index of the first
        //     occurrence within the range of elements in the enumerable
        //     that extends from the specified index to the last element.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The string to locate in the enumerable. 
        /// </param>
        /// <param name="startIndex">
        //     The zero-based starting index of the search. 0 (zero) is valid in an empty list.
        /// </param>
        /// <returns>
        //     The zero-based index of the first occurrence of item within the range of elements
        //     in the enumerable that extends from index to the last
        //     element, if found; otherwise, -1.
        /// </returns>
        public static int IndexOfDevEx(this IEnumerable<string> source, string value, int startIndex)
        {
            return IndexOf(source, value, startIndex, GetCount(source) - startIndex);
        }

        /// <summary>
        //     Searches for the specified object and returns the zero-based index of the first
        //     occurrence within the range of elements in the enumerable
        //     that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to locate in the enumerable. 
        /// </param>
        /// <param name="startIndex">
        //     The zero-based starting index of the search. 0 (zero) is valid in an empty list.
        /// </param>
        /// <param name="count">
        //     The number of elements in the section to search.
        /// </param>
        /// <returns>
        //     The zero-based index of the first occurrence of item within the range of elements
        //     in the enumerable that starts at index and contains count
        //     number of elements, if found; otherwise, -1.
        /// </returns>
        public static int IndexOfDevEx(this IEnumerable<string> source, string value, int startIndex, int count)
        {
            return IndexOf(source, value, startIndex, count);
        }

        /// <summary>
        //     Searches for the specified object and returns the zero-based index of the last
        //     occurrence within the entire enumerable.
        /// </summary>
        /// <param name="source">
        /// </param>
        /// <param name="value">
        //     The object to locate in the enumerable.
        /// </param>
        /// <returns>
        //     The zero-based index of the last occurrence of item within the entire the System.Collections.Generic.List`1,
        //     if found; otherwise, -1.
        /// </returns>
        public static int LastIndexOfDevEx(this IEnumerable<string> source, string value)
        {
            return LastIndexOf(source, value, GetCount(source) - 1, GetCount(source));
        }

        /// <summary>
        //     Searches for the specified object and returns the zero-based index of the last
        //     occurrence within the range of elements in the enumerable
        //     that extends from the first element to the specified index.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to locate in the enumerable
        /// </param>
        /// <param name="startIndex">
        //     The zero-based starting index of the backward search.
        /// </param>
        /// <returns>
        //     The zero-based index of the last occurrence of item within the range of elements
        //     in the enumerable that extends from the first element
        //     to index, if found; otherwise, -1.
        /// </returns>
        public static int LastIndexOfDevEx(this IEnumerable<string> source, string value, int startIndex)
        {
            return LastIndexOf(source, value, startIndex, startIndex + 1);
        }

        /// <summary>
        //     Searches for the specified object and returns the zero-based index of the last
        //     occurrence within the range of elements in the enumerable
        //     that contains the specified number of elements and ends at the specified index.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to locate in the enumerable.
        /// </param>
        /// <param name="startIndex">
        //     The zero-based starting index of the backward search.
        /// </param>
        /// <param name="count">
        //     The number of elements in the section to search.
        /// </param>
        /// <returns>
        //     The zero-based index of the last occurrence of item within the range of elements
        //     in the enumerable that contains count number of elements
        //     and ends at index, if found; otherwise, -1.
        /// </returns>
        public static int LastIndexOfDevEx(this IEnumerable<string> source, string value, int startIndex, int count)
        {
            return LastIndexOf(source, value, startIndex, count);
        }

        /// <summary>
        //     Removes the first occurrence of a specific object from the list.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to remove from the List.
        /// </param>
        /// <returns>
        //     true if item is successfully removed; otherwise, false. This method also returns
        //     false if item was not found.
        /// </returns>
        public static bool RemoveDevEx(this IList<string> source, string value)
        {
            return Remove(source, value);
        }

        /// <summary>
        //     Determines whether an element is in the enumerable
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to locate in the enumerable.
        /// </param>
        /// <returns>
        //     true if item is found in the enumerable; otherwise, false.
        /// </returns>
        private static bool Contains(IEnumerable<string> source, string value)
        {
            bool ret = false;
            if (value == null)
            {
                foreach (string item in source)
                {
                    if (item == null)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (string item in source)
                {
                    if (item.EqualsDevEx(value))
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }
        /// <summary>
        /// Get the number of the elements in the eneumerable
        /// </summary>
        /// <param name="enumerable">Enumerable to count</param>
        /// <returns>Number of the elements in the eneumerable</returns>
        private static int GetCount(IEnumerable enumerable)
        {
            int count = 0;
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                count++;
            }
            return count;
        }
        /// <summary>
        /// Get element ad specified position (base zero) in the enumerable
        /// </summary>
        /// <param name="enumerable">enumerable from where get the element</param>
        /// <param name="index">Zero base index of the element to get</param>
        /// <returns>The element at specified position</returns>
        private static string GetAt(IEnumerable<string> enumerable,int index)
        {
            int count = 0;
            var enumerator = enumerable.GetEnumerator();
            while (count <= index && enumerator.MoveNext())
            {
                count++;
            }
            if (count == index+1)
            {
                return enumerator.Current;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        //     Searches for the specified object and returns the zero-based index of the first
        //     occurrence within the range of elements in the enumerable
        //     that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to locate in the enumerable. 
        /// </param>
        /// <param name="startIndex">
        //     The zero-based starting index of the search. 0 (zero) is valid in an empty list.
        /// </param>
        /// <param name="count">
        //     The number of elements in the section to search.
        /// </param>
        /// <returns>
        //     The zero-based index of the first occurrence of item within the range of elements
        //     in the enumerable that starts at index and contains count
        //     number of elements, if found; otherwise, -1.
        /// </returns>
        private static int IndexOf(IEnumerable<string> source, string value, int startIndex, int count)
        {

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (startIndex > GetCount(source))
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (count < 0 || startIndex > GetCount(source) - count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (startIndex < 0 || startIndex > GetCount(source))
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            int num = startIndex + count;
            for (int i = startIndex; i < num; i++)
            {
                if (GetAt(source,i).EqualsDevEx(value))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        //     Searches for the specified object and returns the zero-based index of the last
        //     occurrence within the range of elements in the enumerable
        //     that contains the specified number of elements and ends at the specified index.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to locate in the enumerable.
        /// </param>
        /// <param name="startIndex">
        //     The zero-based starting index of the backward search.
        /// </param>
        /// <param name="count">
        //     The number of elements in the section to search.
        /// </param>
        /// <returns>
        //     The zero-based index of the last occurrence of item within the range of elements
        //     in the enumerable that contains count number of elements
        //     and ends at index, if found; otherwise, -1.
        /// </returns>
        private static int LastIndexOf(IEnumerable<string> source, string value, int startIndex, int count)
        {

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (GetCount(source) != 0 && startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (GetCount(source) != 0 && count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (GetCount(source) == 0)
            {
                return -1;
            }
            if (startIndex >= GetCount(source))
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (count > startIndex + 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            int num = startIndex - count + 1;
            for (int i = startIndex; i >= num; i--)
            {
                if (GetAt(source,i).EqualsDevEx(value))
                {
                    return i;
                }
            }

            return -1;
        }



        /// <summary>
        //     Removes the first occurrence of a specific object from the list.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        //     The object to remove from the List.
        /// </param>
        /// <returns>
        //     true if item is successfully removed; otherwise, false. This method also returns
        //     false if item was not found.
        /// </returns>
        private static bool Remove(IList<string> source, string value)
        {
            int num = source.IndexOfDevEx(value);
            if (num >= 0)
            {
                source.RemoveAt(num);
                return true;
            }
            return false;
        }

    }
}
