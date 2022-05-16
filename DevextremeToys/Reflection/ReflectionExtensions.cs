using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.Reflection
{
    public static class ReflectionExtensions
    {
        public static object? GetPropertyValue([NotNull] string propertyName, [NotNull] object instance)
        {
            if (string.IsNullOrEmpty(propertyName) || instance == null)
            {
                throw new ArgumentNullException($"{nameof(propertyName)},{nameof(instance)}");
            }
            return instance.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(instance);
        }

        public static void SetPropertyValue([NotNull] string propertyName, object newValue, [NotNull]object instance)
        {
            if(string.IsNullOrEmpty(propertyName) || instance == null)
            {
                throw new ArgumentNullException($"{nameof(propertyName)},{nameof(instance)}");
            }
            instance.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(instance, newValue);
        }

        public static object GetFieldValue([NotNull] string fieldName, [NotNull] object instance)
        {
            if (string.IsNullOrEmpty(fieldName) || instance == null)
            {
                throw new ArgumentNullException($"{nameof(fieldName)},{nameof(instance)}");
            }
            return instance.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);
        }

        public static void SetFieldValue([NotNull] string fieldName, object newValue, [NotNull] object instance)
        {
            if (string.IsNullOrEmpty(fieldName) || instance == null)
            {
                throw new ArgumentNullException($"{nameof(fieldName)},{nameof(instance)}");
            }
            instance.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(instance, newValue);
        }

        public static TA GetPropertyAttribute<TA>(Type objectType, string methodName)
            where TA : Attribute
        {
            TA attr = null;
            var pi = objectType.GetProperty(methodName, BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public);
            var propDescr = TypeDescriptor.GetProperties(pi.ReflectedType).Find(pi.Name, false);
            if (propDescr != null)
            {
                attr = propDescr.Attributes.OfType<TA>().FirstOrDefault();
            }
            return attr;
        }

    }
}
