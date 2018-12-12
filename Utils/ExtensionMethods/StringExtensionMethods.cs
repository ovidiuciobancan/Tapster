using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.String.Extensions
{
    /// <summary>
    /// CommonExtensionMethods 
    /// </summary>
    public static class CommonExtensionMethods
    {
        public static T FromJson<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        public static string SubString(this string value, int start, int end)
        {
            if (!value.HasValue()) return string.Empty;

            if (value.Length < end + 1 || value.Length < start + 1) return string.Empty;

            return value.Substring(start, end - start + 1);
        }
        public static bool HasValue(this string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
        public static bool IsEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }
        public static string Decapitalize(this string value)
        {
            if (value.HasValue())
            {
                return Char.ToLowerInvariant(value[0]) + value.Substring(1);
            }
            return value;
        }
        public static T Cast<T>(this string value)
            where T : IConvertible
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public static List<string> SplitTrim(this string value, string separator)
        {
            return value.SplitTrim(value.ToCharArray());
        }
        public static List<string> SplitTrim(this string value,params string[] separator)
        {
            if (!value.HasValue()) return new List<string>();

            return value.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToList();
        }
        public static List<string> SplitTrim(this string value, params char[] separator)
        {
            if (!value.HasValue()) return new List<string>();

            return value.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToList();
        }
        public static T EnumParse<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}