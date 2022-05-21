using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.StringComparer
{
    /// <summary>
    /// Extension methods for string comparison
    /// </summary>
    public static class StringComparerExtensions
    {

        /// <summary>
        ///     Determines whether two specified System.String objects have the same value.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The second string to compare, or null.
        /// </param>
        /// <returns>
        ///     true if the value of a is the same as the value of b; otherwise, false. If both
        ///     a and b are null, the method returns true.
        /// </returns>
        public static bool EqualsDevEx(this string source, string value)
        {
            return Equals(source, value);
        }

        /// <summary>
        ///     Determines whether two specified System.String objects have the same value.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The second string to compare, or null.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///     true if the value of a is the same as the value of b; otherwise, false. If both
        ///     a and b are null, the method returns true.
        /// </returns>
        public static bool EqualsDevEx(this string source, string value, Settings settings)
        {
            return Equals(source, value, settings);
        }

        /// <summary>
        ///     Compares two specified System.String objects and returns an integer that indicates
        ///     their relative position in the sort order.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The second string to compare.
        /// </param>
        /// <returns>
        ///     A 32-bit signed integer that indicates the lexical relationship between the two
        ///     comparands. Value Condition Less than zero strA precedes strB in the sort order.
        ///     Zero strA occurs in the same position as strB in the sort order. Greater than
        ///     zero strA follows strB in the sort order.
        /// </returns>
        public static int CompareToDevEx(this string source, string value)
        {
            return CompareTo(source, value);
        }
        /// <summary>
        ///     Compares two specified System.String objects and returns an integer that indicates
        ///     their relative position in the sort order.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The second string to compare.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///     A 32-bit signed integer that indicates the lexical relationship between the two
        ///     comparands. Value Condition Less than zero strA precedes strB in the sort order.
        ///     Zero strA occurs in the same position as strB in the sort order. Greater than
        ///     zero strA follows strB in the sort order.
        /// </returns>
        public static int CompareToDevEx(this string source, string value, Settings settings)
        {
            return CompareTo(source, value, settings);
        }

        /// <summary>
        ///     Compares this instance with a specified System.String object and indicates whether
        ///     this instance precedes, follows, or appears in the same position in the sort
        ///     order as the specified string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The string to compare with this instance.
        /// </param>
        /// <returns>
        ///     A 32-bit signed integer that indicates whether this instance precedes, follows,
        ///     or appears in the same position in the sort order as the strB parameter. Value
        ///     Condition Less than zero This instance precedes strB. Zero This instance has
        ///     the same position in the sort order as strB. Greater than zero This instance
        ///     follows strB. -or- strB is null.
        /// </returns>
        public static bool ContainsDevEx(this string source, string value)
        {
            return Contains(source, value);
        }
        /// <summary>
        ///     Compares this instance with a specified System.String object and indicates whether
        ///     this instance precedes, follows, or appears in the same position in the sort
        ///     order as the specified string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The string to compare with this instance.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///     A 32-bit signed integer that indicates whether this instance precedes, follows,
        ///     or appears in the same position in the sort order as the strB parameter. Value
        ///     Condition Less than zero This instance precedes strB. Zero This instance has
        ///     the same position in the sort order as strB. Greater than zero This instance
        ///     follows strB. -or- strB is null.
        /// </returns>
        public static bool ContainsDevEx(this string source, string value, Settings settings)
        {
            return Contains(source, value, settings);
        }

        /// <summary>
        ///     Determines whether the beginning of this string instance matches the specified
        ///     string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The string to compare.
        /// </param>
        /// <returns>
        ///     true if value matches the beginning of this string; otherwise, false.
        /// </returns>
        public static bool StartsWithDevEx(this string source, string value)
        {
            return StartsWith(source, value);
        }
        /// <summary>
        ///     Determines whether the beginning of this string instance matches the specified
        ///     string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The string to compare.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///     true if value matches the beginning of this string; otherwise, false.
        /// </returns>
        public static bool StartsWithDevEx(this string source, string value, Settings settings)
        {
            return StartsWith(source, value);
        }

        /// <summary>
        ///     Determines whether the end of this string instance matches the specified string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The string to compare to the substring at the end of this instance.
        /// </param>
        /// <returns>
        ///     true if value matches the end of this instance; otherwise, false.
        /// </returns>
        public static bool EndsWithDevEx(this string source, string value)
        {
            return EndsWith(source, value);
        }
        /// <summary>
        ///     Determines whether the end of this string instance matches the specified string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The string to compare to the substring at the end of this instance.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///     true if value matches the end of this instance; otherwise, false.
        /// </returns>
        public static bool EndsWithDevEx(this string source, string value, Settings settings)
        {
            return EndsWith(source, value, settings);
        }

        /// <summary>
        ///     Reports the zero-based index of the first occurrence of the specified string
        ///     in this instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The string to seek.
        /// </param>
        /// <returns>
        ///     The zero-based index position of value if that string is found, or -1 if it is
        ///     not. If value is System.String.Empty, the return value is 0.
        /// </returns>
        public static int IndexOfDevEx(this string source, string value)
        {
            return IndexOf(source, value, 0, source.Length);
        }
        /// <summary>
        ///     Reports the zero-based index of the first occurrence of the specified string
        ///     in this instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///     The string to seek.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///     The zero-based index position of value if that string is found, or -1 if it is
        ///     not. If value is System.String.Empty, the return value is 0.
        /// </returns>
        public static int IndexOfDevEx(this string source, string value, Settings settings)
        {
            return IndexOf(source, value, 0, source.Length, settings);
        }

        /// <summary>
        ///     Reports the zero-based index of the first occurrence of the specified string
        ///     in this instance. The search starts at a specified character position.
        /// </summary>
        /// <param name="source">
        ///     The string to seek.
        /// </param>
        /// <param name="value"></param>
        /// <param name="startIndex">
        ///     The search starting position.
        /// </param>
        /// <returns>
        ///     The zero-based index position of value from the start of the current instance
        ///     if that string is found, or -1 if it is not. If value is System.String.Empty,
        ///    the return value is startIndex.
        /// </returns>
        public static int IndexOfDevEx(this string source, string value, int startIndex)
        {
            return IndexOf(source, value, startIndex, source.Length - startIndex);
        }
        /// <summary>
        ///     Reports the zero-based index of the first occurrence of the specified string
        ///     in this instance. The search starts at a specified character position.
        /// </summary>
        /// <param name="source">
        ///     The string to seek.
        /// </param>
        /// <param name="value"></param>
        /// <param name="startIndex">
        ///     The search starting position.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///     The zero-based index position of value from the start of the current instance
        ///     if that string is found, or -1 if it is not. If value is System.String.Empty,
        ///    the return value is startIndex.
        /// </returns>
        public static int IndexOfDevEx(this string source, string value, int startIndex, Settings settings)
        {
            return IndexOf(source, value, startIndex, source.Length - startIndex);
        }

        /// <summary>
        ///    Reports the zero-based index of the first occurrence of the specified string
        ///    in this instance. The search starts at a specified character position and examines
        ///    a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The zero-based index position of value from the start of the current instance
        ///    if that string is found, or -1 if it is not. If value is System.String.Empty,
        ///    the return value is startIndex.
        /// </returns>
        public static int IndexOfDevEx(this string source, string value, int startIndex, int count)
        {
            return IndexOf(source, value, startIndex, count);
        }
        /// <summary>
        ///    Reports the zero-based index of the first occurrence of the specified string
        ///    in this instance. The search starts at a specified character position and examines
        ///    a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of value from the start of the current instance
        ///    if that string is found, or -1 if it is not. If value is System.String.Empty,
        ///    the return value is startIndex.
        /// </returns>
        public static int IndexOfDevEx(this string source, string value, int startIndex, int count, Settings settings)
        {
            return IndexOf(source, value, startIndex, count, settings);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified Unicode
        ///    character within this instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The Unicode character to seek.
        /// </param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not.
        /// </returns>
        public static int IndexOfDevEx(this string source, char value)
        {
            return IndexOf(source, value.ToString(), 0, source.Length);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified Unicode
        ///    character within this instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The Unicode character to seek.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not.
        /// </returns>
        public static int IndexOfDevEx(this string source, char value, Settings settings)
        {
            return IndexOf(source, value.ToString(), 0, source.Length, settings);
        }

        /// <summary>
        ///    Reports the zero-based index of the first occurrence of the specified Unicode
        ///    character in this string. The search starts at a specified character position.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    A Unicode character to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <returns>
        ///    The zero-based index position of value from the start of the string if that character
        ///    is found, or -1 if it is not.
        /// </returns>
        public static int IndexOfDevEx(this string source, char value, int startIndex)
        {
            return IndexOf(source, value.ToString(), startIndex, source.Length - startIndex);
        }
        /// <summary>
        ///    Reports the zero-based index of the first occurrence of the specified Unicode
        ///    character in this string. The search starts at a specified character position.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    A Unicode character to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of value from the start of the string if that character
        ///    is found, or -1 if it is not.
        /// </returns>
        public static int IndexOfDevEx(this string source, char value, int startIndex, Settings settings)
        {
            return IndexOf(source, value.ToString(), startIndex, source.Length - startIndex, settings);
        }

        /// <summary>
        ///    Reports the zero-based index of the first occurrence of the specified character
        ///    in this instance. The search starts at a specified character position and examines
        ///    a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    A Unicode character to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The zero-based index position of value from the start of the string if that character
        ///    is found, or -1 if it is not.
        /// </returns>
        public static int IndexOfDevEx(this string source, char value, int startIndex, int count)
        {
            return IndexOf(source, value.ToString(), startIndex, count);
        }
        /// <summary>
        ///    Reports the zero-based index of the first occurrence of the specified character
        ///    in this instance. The search starts at a specified character position and examines
        ///    a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    A Unicode character to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of value from the start of the string if that character
        ///    is found, or -1 if it is not.
        /// </returns>
        public static int IndexOfDevEx(this string source, char value, int startIndex, int count, Settings settings)
        {
            return IndexOf(source, value.ToString(), startIndex, count);
        }

        /// <summary>
        ///    Reports the zero-based index of the first occurrence in this instance of any
        ///    character in a specified array of Unicode characters.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <returns>
        ///    The zero-based index position of the first occurrence in this instance where
        ///    any character in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        public static int IndexOfAnyDevEx(this string source, char[] anyOf)
        {
            return IndexOfAny(source, anyOf, 0, source.Length);
        }
        /// <summary>
        ///    Reports the zero-based index of the first occurrence in this instance of any
        ///    character in a specified array of Unicode characters.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of the first occurrence in this instance where
        ///    any character in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        public static int IndexOfAnyDevEx(this string source, char[] anyOf, Settings settings)
        {
            return IndexOfAny(source, anyOf, 0, source.Length);
        }

        /// <summary>
        ///    Reports the zero-based index of the first occurrence in this instance of any
        ///    character in a specified array of Unicode characters. The search starts at a
        ///    specified character position.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <returns>
        ///    The zero-based index position of the first occurrence in this instance where
        ///    any character in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        public static int IndexOfAnyDevEx(this string source, char[] anyOf, int startIndex)
        {
            return IndexOfAny(source, anyOf, startIndex, source.Length - startIndex);
        }
        /// <summary>
        ///    Reports the zero-based index of the first occurrence in this instance of any
        ///    character in a specified array of Unicode characters. The search starts at a
        ///    specified character position.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of the first occurrence in this instance where
        ///    any character in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        public static int IndexOfAnyDevEx(this string source, char[] anyOf, int startIndex, Settings settings)
        {
            return IndexOfAny(source, anyOf, startIndex, source.Length - startIndex);
        }

        /// <summary>
        ///    Reports the zero-based index of the first occurrence in this instance of any
        ///    character in a specified array of Unicode characters. The search starts at a
        ///    specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The zero-based index position of the first occurrence in this instance where
        ///    any character in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        public static int IndexOfAnyDevEx(this string source, char[] anyOf, int startIndex, int count)
        {
            return IndexOfAny(source, anyOf, startIndex, count);
        }
        /// <summary>
        ///    Reports the zero-based index of the first occurrence in this instance of any
        ///    character in a specified array of Unicode characters. The search starts at a
        ///    specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of the first occurrence in this instance where
        ///    any character in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        public static int IndexOfAnyDevEx(this string source, char[] anyOf, int startIndex, int count, Settings settings)
        {
            return IndexOfAny(source, anyOf, startIndex, count);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified Unicode
        ///    character within this instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, string value)
        {
            return LastIndexOf(source, value, source.Length - 1, source.Length);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified Unicode
        ///    character within this instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, string value, Settings settings)
        {
            return LastIndexOf(source, value, source.Length - 1, source.Length);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified string
        ///    within this instance. The search starts at a specified character position and
        ///    proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <returns>
        ///    The zero-based starting index position of value if that string is found, or -1
        ///    if it is not found or if the current instance equals System.String.Empty. If
        ///    value is System.String.Empty, the return value is the smaller of startIndex and
        ///    the last index position in this instance.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, string value, int startIndex)
        {
            return LastIndexOf(source, value, startIndex, startIndex + 1);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified string
        ///    within this instance. The search starts at a specified character position and
        ///    proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based starting index position of value if that string is found, or -1
        ///    if it is not found or if the current instance equals System.String.Empty. If
        ///    value is System.String.Empty, the return value is the smaller of startIndex and
        ///    the last index position in this instance.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, string value, int startIndex, Settings settings)
        {
            return LastIndexOf(source, value, startIndex, startIndex + 1);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified string
        ///    within this instance. The search starts at a specified character position and
        ///    proceeds backward toward the beginning of the string for a specified number of
        ///    character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The zero-based starting index position of value if that string is found, or -1
        ///    if it is not found or if the current instance equals System.String.Empty. If
        ///    value is System.String.Empty, the return value is the smaller of startIndex and
        ///    the last index position in this instance.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, string value, int startIndex, int count)
        {
            return LastIndexOf(source, value, startIndex, count);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified string
        ///    within this instance. The search starts at a specified character position and
        ///    proceeds backward toward the beginning of the string for a specified number of
        ///    character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based starting index position of value if that string is found, or -1
        ///    if it is not found or if the current instance equals System.String.Empty. If
        ///    value is System.String.Empty, the return value is the smaller of startIndex and
        ///    the last index position in this instance.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, string value, int startIndex, int count, Settings settings)
        {
            return LastIndexOf(source, value, startIndex, count);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified Unicode
        ///    character within this instance. The search starts at a specified character position
        ///    and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The Unicode character to seek.
        /// </param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, char value)
        {
            return LastIndexOf(source, value.ToString(), source.Length - 1, source.Length);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified Unicode
        ///    character within this instance. The search starts at a specified character position
        ///    and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The Unicode character to seek.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, char value, Settings settings)
        {
            return LastIndexOf(source, value.ToString(), source.Length - 1, source.Length);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified Unicode
        ///    character within this instance. The search starts at a specified character position
        ///    and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The Unicode character to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The starting position of the search. The search proceeds from startIndex toward
        ///    the beginning of this instance.
        /// </param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not found or if the current instance equals System.String.Empty.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, char value, int startIndex)
        {
            return LastIndexOf(source, value.ToString(), startIndex, startIndex + 1);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified Unicode
        ///    character within this instance. The search starts at a specified character position
        ///    and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The Unicode character to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The starting position of the search. The search proceeds from startIndex toward
        ///    the beginning of this instance.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not found or if the current instance equals System.String.Empty.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, char value, int startIndex, Settings settings)
        {
            return LastIndexOf(source, value.ToString(), startIndex, startIndex + 1);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of the specified
        ///    Unicode character in a substring within this instance. The search starts at a
        ///    specified character position and proceeds backward toward the beginning of the
        ///    string for a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The Unicode character to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The starting position of the search. The search proceeds from startIndex toward
        ///    the beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not found or if the current instance equals System.String.Empty.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, char value, int startIndex, int count)
        {
            return LastIndexOf(source, value.ToString(), startIndex, count);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of the specified
        ///    Unicode character in a substring within this instance. The search starts at a
        ///    specified character position and proceeds backward toward the beginning of the
        ///    string for a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The Unicode character to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The starting position of the search. The search proceeds from startIndex toward
        ///    the beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of value if that character is found, or -1 if it
        ///    is not found or if the current instance equals System.String.Empty.
        /// </returns>
        public static int LastIndexOfDevEx(this string source, char value, int startIndex, int count, Settings settings)
        {
            return LastIndexOf(source, value.ToString(), startIndex, count);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence in this instance
        ///    of one or more characters specified in a Unicode array.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <returns>
        ///    The index position of the last occurrence in this instance where any character
        ///    in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        public static int LastIndexOfAnyDevEx(this string source, char[] anyOf)
        {
            return LastIndexOfAny(source, anyOf, source.Length - 1, source.Length);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence in this instance
        ///    of one or more characters specified in a Unicode array.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The index position of the last occurrence in this instance where any character
        ///    in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        public static int LastIndexOfAnyDevEx(this string source, char[] anyOf, Settings settings)
        {
            return LastIndexOfAny(source, anyOf, source.Length - 1, source.Length);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence in this instance
        ///    of one or more characters specified in a Unicode array. The search starts at
        ///    a specified character position and proceeds backward toward the beginning of
        ///    the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <returns>
        ///    The index position of the last occurrence in this instance where any character
        ///    in anyOf was found; -1 if no character in anyOf was found or if the current instance
        ///    equals System.String.Empty.
        /// </returns>
        public static int LastIndexOfAnyDevEx(this string source, char[] anyOf, int startIndex)
        {
            return LastIndexOfAny(source, anyOf, startIndex, startIndex + 1);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence in this instance
        ///    of one or more characters specified in a Unicode array. The search starts at
        ///    a specified character position and proceeds backward toward the beginning of
        ///    the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The index position of the last occurrence in this instance where any character
        ///    in anyOf was found; -1 if no character in anyOf was found or if the current instance
        ///    equals System.String.Empty.
        /// </returns>
        public static int LastIndexOfAnyDevEx(this string source, char[] anyOf, int startIndex, Settings settings)
        {
            return LastIndexOfAny(source, anyOf, startIndex, startIndex + 1);
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence in this instance
        ///    of one or more characters specified in a Unicode array. The search starts at
        ///    a specified character position and proceeds backward toward the beginning of
        ///    the string for a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The index position of the last occurrence in this instance where any character
        ///    in anyOf was found; -1 if no character in anyOf was found or if the current instance
        ///    equals System.String.Empty.
        /// </returns>
        public static int LastIndexOfAnyDevEx(this string source, char[] anyOf, int startIndex, int count)
        {
            return LastIndexOfAny(source, anyOf, startIndex, count);
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence in this instance
        ///    of one or more characters specified in a Unicode array. The search starts at
        ///    a specified character position and proceeds backward toward the beginning of
        ///    the string for a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The index position of the last occurrence in this instance where any character
        ///    in anyOf was found; -1 if no character in anyOf was found or if the current instance
        ///    equals System.String.Empty.
        /// </returns>
        public static int LastIndexOfAnyDevEx(this string source, char[] anyOf, int startIndex, int count, Settings settings)
        {
            return LastIndexOfAny(source, anyOf, startIndex, count);
        }

        /// <summary>
        /// Compare two strings using current compare settings
        /// </summary>
        /// <param name="source">first string to compare</param>
        /// <param name="value">second stirng to compare</param>
        /// <returns>
        ///    A 32-bit signed integer indicating the lexical relationship between the two comparands.
        ///    Value Condition zero The two strings are equal. less than zero string1 is less
        ///    than string2. greater than zero string1 is greater than string2.
        /// </returns>
        private static int CompareTo(string source, string value)
        {
            return CultureInfo.CurrentCulture.CompareInfo.Compare(source, value, CompareSettings.Instance.GetCompareOptions());
        }
        /// <summary>
        /// Compare two strings using current compare settings
        /// </summary>
        /// <param name="source">first string to compare</param>
        /// <param name="value">second stirng to compare</param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    A 32-bit signed integer indicating the lexical relationship between the two comparands.
        ///    Value Condition zero The two strings are equal. less than zero string1 is less
        ///    than string2. greater than zero string1 is greater than string2.
        /// </returns>
        private static int CompareTo(string source, string value, Settings settings)
        {
            return CultureInfo.CurrentCulture.CompareInfo.Compare(source, value, CompareSettings.Instance.GetCompareOptions(settings));
        }

        /// <summary>
        /// Check if second string is contained in first string using currnet compare settings
        /// </summary>
        /// <param name="source">first string where look for second</param>
        /// <param name="value">string to look for</param>
        /// <returns>
        /// True if source contains value
        /// </returns>
        private static bool Contains(string source, string value)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(source, value, CompareSettings.Instance.GetCompareOptions()) >= 0;
        }
        /// <summary>
        /// Check if second string is contained in first string using currnet compare settings
        /// </summary>
        /// <param name="source">first string where look for second</param>
        /// <param name="value">string to look for</param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        /// True if source contains value
        /// </returns>
        private static bool Contains(string source, string value, Settings settings)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(source, value, CompareSettings.Instance.GetCompareOptions(settings)) >= 0;
        }

        /// <summary>
        ///    Determines whether the specified source string ends with the specified suffix
        ///    using current compare settings
        /// </summary>
        /// <param name="source">
        ///    The string to search in.
        /// </param>
        /// <param name="value">
        ///    The string to compare with the end of source.
        /// </param>
        /// <returns>
        ///    true if the length of suffix is less than or equal to the length of source and
        ///    source ends with suffix; otherwise, false.
        /// </returns>
        private static bool EndsWith(string source, string value)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(source, value, CompareSettings.Instance.GetCompareOptions());
        }
        /// <summary>
        ///    Determines whether the specified source string ends with the specified suffix
        ///    using current compare settings
        /// </summary>
        /// <param name="source">
        ///    The string to search in.
        /// </param>
        /// <param name="value">
        ///    The string to compare with the end of source.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    true if the length of suffix is less than or equal to the length of source and
        ///    source ends with suffix; otherwise, false.
        /// </returns>
        private static bool EndsWith(string source, string value, Settings settings)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(source, value, CompareSettings.Instance.GetCompareOptions(settings));
        }

        /// <summary>
        ///    Compares two strings using current compare settings
        /// </summary>
        /// <param name="source">
        ///    The first string to compare.
        /// </param>
        /// <param name="value">
        ///    The second string to compare.
        /// </param>
        /// <returns>
        ///    A 32-bit signed integer indicating the lexical relationship between the two comparands.
        ///    Value Condition zero The two strings are equal. less than zero string1 is less
        ///    than string2. greater than zero string1 is greater than string2.
        /// </returns>
        private static bool Equals(string source, string value)
        {
            return CultureInfo.CurrentCulture.CompareInfo.Compare(source, value, CompareSettings.Instance.GetCompareOptions()) == 0;
        }
        /// <summary>
        ///    Compares two strings using current compare settings
        /// </summary>
        /// <param name="source">
        ///    The first string to compare.
        /// </param>
        /// <param name="value">
        ///    The second string to compare.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    A 32-bit signed integer indicating the lexical relationship between the two comparands.
        ///    Value Condition zero The two strings are equal. less than zero string1 is less
        ///    than string2. greater than zero string1 is greater than string2.
        /// </returns>
        private static bool Equals(string source, string value, Settings settings)
        {
            return CultureInfo.CurrentCulture.CompareInfo.Compare(source, value, CompareSettings.Instance.GetCompareOptions(settings)) == 0;
        }
        /// <summary>
        ///    Searches for the specified substring and returns the zero-based index of the
        ///    first occurrence within the section of the source string that starts at the specified
        ///    index and contains the specified number of elements using the specified System.Globalization.CompareOptions
        ///    value.
        /// </summary>
        /// <param name="source">
        ///    The string to search.
        /// </param>
        /// <param name="value">
        ///    The string to locate within source.
        /// </param>
        /// <param name="startIndex">
        ///    The zero-based starting index of the search.
        /// </param>
        /// <param name="count">
        ///    The number of elements in the section to search.
        /// </param>
        /// <returns>
        ///    The zero-based index of the first occurrence of value, if found, within the section
        ///    of source that starts at startIndex and contains the number of elements specified
        ///    by count, using the specified comparison options; otherwise, -1. Returns startIndex
        ///    if value is an ignorable character.
        /// </returns>
        private static int IndexOf(string source, string value, int startIndex, int count)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(source, value, startIndex, count, CompareSettings.Instance.GetCompareOptions());
        }

        /// <summary>
        ///    Searches for the specified substring and returns the zero-based index of the
        ///    first occurrence within the section of the source string that starts at the specified
        ///    index and contains the specified number of elements using the specified System.Globalization.CompareOptions
        ///    value.
        /// </summary>
        /// <param name="source">
        ///    The string to search.
        /// </param>
        /// <param name="value">
        ///    The string to locate within source.
        /// </param>
        /// <param name="startIndex">
        ///    The zero-based starting index of the search.
        /// </param>
        /// <param name="count">
        ///    The number of elements in the section to search.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index of the first occurrence of value, if found, within the section
        ///    of source that starts at startIndex and contains the number of elements specified
        ///    by count, using the specified comparison options; otherwise, -1. Returns startIndex
        ///    if value is an ignorable character.
        /// </returns>
        private static int IndexOf(string source, string value, int startIndex, int count, Settings settings)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(source, value, startIndex, count, CompareSettings.Instance.GetCompareOptions(settings));
        }

        /// <summary>
        ///    Reports the zero-based index of the first occurrence in this instance of any
        ///    character in a specified array of Unicode characters. The search starts at a
        ///    specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The zero-based index position of the first occurrence in this instance where
        ///    any character in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        private static int IndexOfAny(string source, char[] anyOf, int startIndex, int count)
        {
            int index = -1;

            if (anyOf != null)
            {
                foreach (char c in anyOf)
                {
                    int currentIndex = IndexOf(source, c.ToString(), startIndex, count);
                    if (currentIndex >= 0 && (index == -1 || currentIndex < index))
                    {
                        index = currentIndex;
                    }
                }
            }

            return index;
        }
        /// <summary>
        ///    Reports the zero-based index of the first occurrence in this instance of any
        ///    character in a specified array of Unicode characters. The search starts at a
        ///    specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based index position of the first occurrence in this instance where
        ///    any character in anyOf was found; -1 if no character in anyOf was found.
        /// </returns>
        private static int IndexOfAny(string source, char[] anyOf, int startIndex, int count, Settings settings)
        {
            int index = -1;

            if (anyOf != null)
            {
                foreach (char c in anyOf)
                {
                    int currentIndex = IndexOf(source, c.ToString(), startIndex, count, settings);
                    if (currentIndex >= 0 && (index == -1 || currentIndex < index))
                    {
                        index = currentIndex;
                    }
                }
            }

            return index;
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified string
        ///    within this instance. The search starts at a specified character position and
        ///    proceeds backward toward the beginning of the string for a specified number of
        ///    character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The zero-based starting index position of value if that string is found, or -1
        ///    if it is not found or if the current instance equals System.String.Empty. If
        ///    value is System.String.Empty, the return value is the smaller of startIndex and
        ///    the last index position in this instance.
        /// </returns>
        private static int LastIndexOf(string source, string value, int startIndex, int count)
        {
            return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(source, value, startIndex, count, CompareSettings.Instance.GetCompareOptions());
        }
        /// <summary>
        ///    Reports the zero-based index position of the last occurrence of a specified string
        ///    within this instance. The search starts at a specified character position and
        ///    proceeds backward toward the beginning of the string for a specified number of
        ///    character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">
        ///    The string to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The zero-based starting index position of value if that string is found, or -1
        ///    if it is not found or if the current instance equals System.String.Empty. If
        ///    value is System.String.Empty, the return value is the smaller of startIndex and
        ///    the last index position in this instance.
        /// </returns>
        private static int LastIndexOf(string source, string value, int startIndex, int count, Settings settings)
        {
            return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(source, value, startIndex, count, CompareSettings.Instance.GetCompareOptions(settings));
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence in this instance
        ///    of one or more characters specified in a Unicode array. The search starts at
        ///    a specified character position and proceeds backward toward the beginning of
        ///    the string for a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <returns>
        ///    The index position of the last occurrence in this instance where any character
        ///    in anyOf was found; -1 if no character in anyOf was found or if the current instance
        ///    equals System.String.Empty.
        /// </returns>
        private static int LastIndexOfAny(string source, char[] anyOf, int startIndex, int count)
        {
            int index = -1;

            if (anyOf != null)
            {
                foreach (char c in anyOf)
                {
                    int currentIndex = LastIndexOf(source, c.ToString(), startIndex, count);
                    if (currentIndex >= 0 && (index == -1 || currentIndex > index))
                    {
                        index = currentIndex;
                    }
                }
            }

            return index;
        }

        /// <summary>
        ///    Reports the zero-based index position of the last occurrence in this instance
        ///    of one or more characters specified in a Unicode array. The search starts at
        ///    a specified character position and proceeds backward toward the beginning of
        ///    the string for a specified number of character positions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="anyOf">
        ///    A Unicode character array containing one or more characters to seek.
        /// </param>
        /// <param name="startIndex">
        ///    The search starting position. The search proceeds from startIndex toward the
        ///    beginning of this instance.
        /// </param>
        /// <param name="count">
        ///    The number of character positions to examine.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    The index position of the last occurrence in this instance where any character
        ///    in anyOf was found; -1 if no character in anyOf was found or if the current instance
        ///    equals System.String.Empty.
        /// </returns>
        private static int LastIndexOfAny(string source, char[] anyOf, int startIndex, int count, Settings settings)
        {
            int index = -1;

            if (anyOf != null)
            {
                foreach (char c in anyOf)
                {
                    int currentIndex = LastIndexOf(source, c.ToString(), startIndex, count, settings);
                    if (currentIndex >= 0 && (index == -1 || currentIndex > index))
                    {
                        index = currentIndex;
                    }
                }
            }

            return index;
        }

        /// <summary>
        ///    Determines whether the specified source string starts with the specified prefix
        ///    using the specified System.Globalization.CompareOptions value.
        /// </summary>
        /// <param name="source">
        ///    The string to search in.
        /// </param>
        /// <param name="value">
        ///    The string to compare with the beginning of source.
        /// </param>
        /// <returns>
        ///    true if the length of prefix is less than or equal to the length of source and
        ///    source starts with prefix; otherwise, false.
        /// </returns>
        private static bool StartsWith(string source, string value)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(source, value, CompareSettings.Instance.GetCompareOptions());
        }
        /// <summary>
        ///    Determines whether the specified source string starts with the specified prefix
        ///    using the specified System.Globalization.CompareOptions value.
        /// </summary>
        /// <param name="source">
        ///    The string to search in.
        /// </param>
        /// <param name="value">
        ///    The string to compare with the beginning of source.
        /// </param>
        /// <param name="settings">Setting used for comparison</param>
        /// <returns>
        ///    true if the length of prefix is less than or equal to the length of source and
        ///    source starts with prefix; otherwise, false.
        /// </returns>
        private static bool StartsWith(string source, string value, Settings settings)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(source, value, CompareSettings.Instance.GetCompareOptions(settings));
        }
    }
}