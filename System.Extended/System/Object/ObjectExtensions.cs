using System.Linq;
using System.Reflection;

namespace System
{
    /// <summary>
    /// Extensions for <see cref="object"/>.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Replacing any properties in target object from second object.
        /// </summary>
        /// <param name="target">Target object.</param>
        /// <param name="replaceBy">Second object.</param>
        /// <param name="flags">Flags for finding properties.</param>
        /// <returns>
        /// Count of replaced properties.
        /// </returns>
        public static int ReplaceBy(this object target, object replaceBy, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            target.EnsureNotNull(nameof(target));
            target.EnsureNotNull(nameof(replaceBy));
            var props = target.GetType().GetProperties(flags);
            var byProps = replaceBy.GetType().GetProperties(flags);

            var join = props.Join(byProps, x => x.Name, x => x.Name, (left, right) => new { target = left, by = right })
                            .Where(x => x.target.SetMethod != null && x.by.GetMethod != null);

            if (join.Any())
            {
                join.ForEach(item =>
                {
                    var newValue = item.by.GetValue(replaceBy);
                    item.target.SetValue(target, newValue);
                });

                return join.Count();
            }

            return -1;
        }
    }
}
