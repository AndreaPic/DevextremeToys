using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.List
{
    /// <summary>
    /// Extensions for enumerable types
    /// </summary>
    public static class CollectionExtensions
    {

        /// <summary>
        /// Validate split arguments
        /// </summary>
        /// <typeparam name="T">list's item type</typeparam>
        /// <param name="list">list to split</param>
        /// <param name="splitSize">Splitting size for sub lists</param>
        /// <exception cref="ArgumentNullException">list must be not null</exception>
        /// <exception cref="ArgumentOutOfRangeException">splitSize must be greater than zero.</exception>
        private static void ValidateSplit<T>(IEnumerable<T> list, int splitSize)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (splitSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(splitSize));
            }
        }

        /// <summary>
        /// Split a list and return a list of sub-lists of specified size
        /// </summary>
        /// <typeparam name="T">List object type</typeparam>
        /// <param name="list">list to extend</param>
        /// <param name="splitSize">sub lists size, must be greater than zero</param>
        /// <returns>List of sub-lists</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int splitSize)
        {
            var ret = new List<IEnumerable<T>>();
            long itemCount = Math.DivRem(list.Count(), splitSize, out long rem);
            if (rem > 0)
            {
                itemCount++;
            }
            for (var i = 0; i < itemCount; i++)
            {
                ret.Add(list.Skip(i * splitSize).Take(splitSize));
            }
            return ret;
        }

        /// <summary>
        /// Split a list and return a list of sub-lists of specified size
        /// </summary>
        /// <typeparam name="T">List object type</typeparam>
        /// <param name="list">list to extend</param>
        /// <param name="splitSize">sub lists size, must be greater than zero</param>
        /// <returns>List of sub-lists</returns>
        public static List<List<T>> Split<T>(this List<T> list, int splitSize)
        {
            var ret = new List<List<T>>();
            long itemCount = Math.DivRem(list.Count(), splitSize, out long rem);
            if (rem > 0)
            {
                itemCount++;
            }
            for (var i = 0; i < itemCount; i++)
            {
                ret.Add(list.Skip(i * splitSize).Take(splitSize).ToList());
            }
            return ret;
        }
    }
}
