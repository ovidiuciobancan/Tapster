using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace Utils.ExtensionMethods
{
    public static class HttpClientExtensionMethods
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            var uri = new Uri(client.BaseAddress, requestUri);

            return await PatchAsync(client, uri, content);
        }

        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };

            return await client.SendAsync(request);
        }

        public static Uri AddParameter(this Uri url, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = QueryHelpers.ParseQuery(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        public static Uri AddParameters(this Uri url, object parameters)
        {
            var uriBuilder = new UriBuilder(url);
            var query = QueryHelpers.ParseQuery(uriBuilder.Query);
            var values = parameters.GetType().GetProperties()
                .Where(p => p.GetMethod != null)
                .ToList();

            foreach (var prop in values)
            {
                query[prop.Name.ToLower()] = prop.GetValue(parameters).ToString();
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}