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
    /// <summary>
    /// General utility for every objects
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Get current value from a property
        /// </summary>
        /// <param name="propertyName">Property name from get the value</param>
        /// <param name="instance">Object instance of the property</param>
        /// <returns>property value</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static object? GetPropertyValue(this object instance, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || instance == null)
            {
                throw new ArgumentNullException($"{nameof(propertyName)},{nameof(instance)}");
            }
            return instance.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(instance);
        }

        /// <summary>
        /// Set value to a property
        /// </summary>
        /// <param name="propertyName">Property name where set the value</param>
        /// <param name="newValue">New valuefor the property</param>
        /// <param name="instance">Object instance of the property</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetPropertyValue(this object instance, [NotNull] string propertyName, object newValue)
        {
            if(string.IsNullOrEmpty(propertyName) || instance == null)
            {
                throw new ArgumentNullException($"{nameof(propertyName)},{nameof(instance)}");
            }
            instance.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(instance, newValue);
        }

        /// <summary>
        /// Get current value from a field
        /// </summary>
        /// <param name="fieldName">Field name from get the value</param>
        /// <param name="instance">Object instance of the filed</param>
        /// <returns>Field value</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static object GetFieldValue(this object instance, [NotNull] string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName) || instance == null)
            {
                throw new ArgumentNullException($"{nameof(fieldName)},{nameof(instance)}");
            }
            return instance.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);
        }

        /// <summary>
        /// Set value to a field
        /// </summary>
        /// <param name="fieldName">Field name where set the new value</param>
        /// <param name="newValue">New value for the field</param>
        /// <param name="instance">Object instance of the filed</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetFieldValue(this object instance, [NotNull] string fieldName, object newValue)
        {
            if (string.IsNullOrEmpty(fieldName) || instance == null)
            {
                throw new ArgumentNullException($"{nameof(fieldName)},{nameof(instance)}");
            }
            instance.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(instance, newValue);
        }

        /// <summary>
        /// Get an attribute from a property (if both exists)
        /// </summary>
        /// <typeparam name="TA">Attribute to look for</typeparam>
        /// <param name="objectType">Object Type of the property</param>
        /// <param name="propertyName">Name of the property to look for</param>
        /// <returns>Attribute if exists</returns>
        public static TA? GetPropertyAttribute<TA>(this Type objectType, string propertyName)
            where TA : Attribute
        {
            TA? attr = null;
            var pi = objectType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public);
            if (pi != null)
            { 
                var propDescr = TypeDescriptor.GetProperties(pi.ReflectedType).Find(pi.Name, false);
                if (propDescr != null)
                {
                    attr = propDescr.Attributes.OfType<TA>().FirstOrDefault();
                }
            }
            return attr;
        }

        /// <summary>
        /// Get an attribute from a field (if both exists)
        /// </summary>
        /// <typeparam name="TA">Attribute to look for</typeparam>
        /// <param name="objectType">Object Type of the property</param>
        /// <param name="fieldName">Name of the property to look for</param>
        /// <returns>Attribute if exists</returns>
        public static TA? GetFiledAttribute<TA>(this Type objectType, string fieldName)
            where TA : Attribute
        {
            TA? attr = null;
            var fi = objectType.GetField(fieldName, BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public);
            if (fi != null)
            {
                var propDescr = TypeDescriptor.GetProperties(fi.ReflectedType).Find(fi.Name, false);
                if (propDescr != null)
                {
                    attr = propDescr.Attributes.OfType<TA>().FirstOrDefault();
                }
            }
            return attr;
        }


    }
}
