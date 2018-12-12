using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Utils.Configuration.Extensions
{
    public static class ConfigurationExtensionMethods
    {
        public static T GetConfiguration<T>(this IConfiguration config, string sectionName = null)
            where T : class, new()
        {
            var result = new T();
            sectionName = sectionName ?? typeof(T).GetTypeInfo().Name; 
            config.GetSection(sectionName).Bind(result);
            return result;
        }
    }
}