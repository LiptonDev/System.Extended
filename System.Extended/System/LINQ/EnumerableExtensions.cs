using System.Collections.Generic;

namespace System.Linq
{
    public delegate void ForEachDelegate<T>(T item, int index);

    /// <summary>
    /// Extensions for LINQ.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Joining collection inq string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Collection.</param>
        /// <param name="selector">Property selector.</param>
        /// <param name="separator">Separator.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static string JoinString<T>(this IEnumerable<T> values, Func<T, object> selector, string separator)
        {
            values.EnsureNotNull(nameof(values));
            separator.EnsureNotNull(nameof(separator));

            return string.Join(separator, values.Select(selector));
        }

        /// <summary>
        /// Joining collection inq string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Collection.</param>
        /// <param name="separator">Separator.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static string JoinString<T>(this IEnumerable<T> values, string separator)
        {
            return values.JoinString(x => x, separator);
        }

        /// <summary>
        /// Shuffle the entire collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> values)
        {
            values.EnsureNotNull(nameof(values));

            return values.OrderBy(_ => Guid.NewGuid());
        }

        /// <summary>
        ///  Check collection to empty or null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static bool IsEmptyOrNull<T>(this IEnumerable<T> values)
        {
            return values == null || !values.Any();
        }

        /// <summary>
        /// Check collection to empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static bool IsEmpty<T>(this IEnumerable<T> values)
        {
            values.EnsureNotNull(nameof(values));

            return !values.Any();
        }

        /// <summary>
        /// Performs the specified action on each item in the collection and returns the same list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Collection.</param>
        /// <param name="action">Action.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> Pipe<T>(this IEnumerable<T> values, ForEachDelegate<T> action)
        {
            values.ForEach(action);

            return values;
        }

        /// <summary>
        /// Performs the specified action on each item in the collection and returns the same list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Collection.</param>
        /// <param name="action">Action.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> Pipe<T>(this IEnumerable<T> values, Action<T> action)
        {
            values.ForEach(action);

            return values;
        }

        /// <summary>
        /// Create collection from 1 item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">Item.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            item.EnsureNotNull(nameof(item));

            yield return item;
        }

        /// <summary>
        /// Performs the specified action on each item in the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Values.</param>
        /// <param name="action">Action.</param>
        /// <exception cref="ArgumentNullException"/>
        public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
        {
            values.ForEach((item, _) => action(item));
        }

        /// <summary>
        /// Performs the specified action on each item in the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Values.</param>
        /// <param name="forEachDelegate">Action.</param>
        /// <exception cref="ArgumentNullException"/>
        public static void ForEach<T>(this IEnumerable<T> values, ForEachDelegate<T> forEachDelegate)
        {
            values.EnsureNotNull(nameof(values));
            forEachDelegate.EnsureNotNull(nameof(forEachDelegate));

            int i = 0;
            foreach (var item in values)
            {
                forEachDelegate(item, i++);
            }
        }
    }
}