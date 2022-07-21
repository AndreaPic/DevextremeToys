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
            PropertyInfo? pi = GetPropertyInfo(instance, propertyName);
            return pi?.GetValue(instance); ;
        }

        /// <summary>
        /// Get PropertyInfo from instance
        /// </summary>
        /// <param name="instance">Instance where look for proeprty</param>
        /// <param name="propertyName">Name of the property to look for</param>
        /// <returns>PropertyInfo or null</returns>
        private static PropertyInfo? GetPropertyInfo(object instance, string propertyName)
        {
            return GetPropertyInfo(instance.GetType(), propertyName);
        }
        
        /// <summary>
        /// Get PropertyInfo from instance
        /// </summary>
        /// <param name="instance">Type where look for proeprty</param>
        /// <param name="propertyName">Name of the property to look for</param>
        /// <returns>PropertyInfo or null</returns>
        private static PropertyInfo? GetPropertyInfo(Type objectType, string propertyName)
        {
            PropertyInfo? pi = null;
            try
            {
                pi = objectType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            }
            catch (AmbiguousMatchException)
            {
                try
                {
                    pi = objectType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                }
                catch (AmbiguousMatchException)
                {
                    pi = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(p => p.Name == propertyName);
                }
            }
            return pi;
        }

        /// <summary>
        /// Get FieldInfo from instance
        /// </summary>
        /// <param name="instance">Instance where look for field</param>
        /// <param name="fieldName">Name of the field to look for</param>
        /// <returns>PropertyInfo or null</returns>
        private static FieldInfo? GetFieldInfoInfo(object instance, string fieldName)
        {
            return GetFieldInfoInfo(instance.GetType(), fieldName);
        }

        /// <summary>
        /// Get FieldInfo from instance
        /// </summary>
        /// <param name="instance">Type where look for field</param>
        /// <param name="fieldName">Name of the field to look for</param>
        /// <returns>PropertyInfo or null</returns>
        private static FieldInfo? GetFieldInfoInfo(Type objectType, string fieldName)
        {
            FieldInfo? pi = null;
            try
            {
                pi = objectType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            }
            catch (AmbiguousMatchException)
            {
                try
                {
                    pi = objectType.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                }
                catch (AmbiguousMatchException)
                {
                    pi = objectType.GetFields(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(p => p.Name == fieldName);
                }
            }
            return pi;
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
            PropertyInfo? pi = GetPropertyInfo(instance, propertyName);
            pi?.SetValue(instance, newValue);
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
            PropertyInfo? pi = GetPropertyInfo(instance, fieldName);
            return pi?.GetValue(instance);
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
            PropertyInfo? pi = GetPropertyInfo(instance, fieldName);
            pi?.SetValue(instance, newValue);
        }

        /// <summary>
        /// Get an attribute from a property (if both exists)
        /// </summary>
        /// <typeparam name="TA">Attribute to look for</typeparam>
        /// <param name="objectType">Object Type of the property</param>
        /// <param name="propertyName">Name of the property to look for</param>
        /// <returns>Attribute if exists</returns>
        public static TA GetPropertyAttribute<TA>(this Type objectType, string propertyName)
            where TA : Attribute
        {
            TA attr = null;
            PropertyInfo? pi = GetPropertyInfo(objectType, propertyName);
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
        public static TA GetFiledAttribute<TA>(this Type objectType, string fieldName)
            where TA : Attribute
        {
            TA attr = null;
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

        /// <summary>
        /// Return property names of a specific type
        /// </summary>
        /// <param name="objectType">Type where look for properties</param>
        /// <returns>Sequence of property name</returns>
        public static IEnumerable<string> GetPropertyNames(this Type objectType)
        {
            IEnumerable<string> names = null;

            var properties = objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            if (properties != null)
            {
                names = properties.Select(p => p.Name).ToList();
            }
            else
            {
                names = new List<string>();
            }
                
            return names;
        }

        /// <summary>
        /// Return field names of a specific type
        /// </summary>
        /// <param name="objectType">Type where look for fields</param>
        /// <returns>Sequence of field name</returns>
        public static IEnumerable<string> GetFieldNames(this Type objectType)
        {
            IEnumerable<string> names = null;

            var fields = objectType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            if (fields != null)
            {
                names = fields.Select(p => p.Name).ToList();
            }
            else
            {
                names = new List<string>();
            }

            return names;
        }

        /// <summary>
        /// Get a specific attribute from specific type
        /// </summary>
        /// <typeparam name="TAttr">Attribute to look for</typeparam>
        /// <param name="type">Type to extend</param>
        /// <returns>Attribute if exists otherwise null</returns>
        public static TAttr GetAttribute<TAttr>(this Type type)
            where TAttr : Attribute
        {
            TAttr attr = TypeDescriptor.GetAttributes(type).OfType<TAttr>().FirstOrDefault();
            return attr;
        }

        /// <summary>
        /// Get attributes from specific type
        /// </summary>
        /// <param name="type">Type to extend</param>
        /// <returns>Attributes</returns>
        public static IEnumerable<Attribute> GetAttributes(this Type type)
        {
            return TypeDescriptor.GetAttributes(type).OfType<Attribute>();
        }


    }
}
