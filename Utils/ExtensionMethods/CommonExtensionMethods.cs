using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;

namespace Utils.Extensions
{
    public static class Constants
    {
        public static readonly string[] PossibleDateFormats = new string[] { "M/d/yyyy", "M-d-yyyy", "M/d/yy", "M-d-yy", "M-d", "M/d" };
    }

    /// <summary>
    /// CommonExtensionMethods 
    /// </summary>
    public static class CommonExtensionMethods
    {
        public static byte[] ToByteArray(this IFormFile formFile)
        {
            using(var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Serialize objects using JSON from NewtonSoft
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public static bool TryApplyTo<T>(this JsonPatchDocument<T> jsonPatchDocument, T model)
            where T : class
        {
            try
            {
                jsonPatchDocument.ApplyTo(model);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// verifies if is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNullString(this object value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

        public static string ToText(this byte[] content)
        {
            if (content == null) return string.Empty;
            return Encoding.UTF8.GetString(content);
        }

        public static StringContent ToStringContent<T>(this T obj) 
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }



        public static void GenerateJsonFile(this object data, string filePath)
        {
            var dirPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            using (var sw = File.CreateText(filePath))
            {
                sw.Write(JsonConvert.SerializeObject(data, Formatting.Indented));
            }
        }
    }

    public class Enum<T> where T : struct, IConvertible
    {
        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<string> Names
        {
            get
            {
                if (!typeof(T).GetTypeInfo().IsEnum)
                {
                    throw new ArgumentException("T must be an enumerated type");
                }

                return Enum.GetNames(typeof(T)).ToList();
            }
        }
    }
}