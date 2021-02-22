using Microsoft.AspNetCore.Http;
using System.Linq;

namespace folea.Serilog.Enrichers.HttpHeaders.Extensions
{
    internal static class HttpContextExtensions
    {
        /// <summary>
        /// If the header key is not present in the Request then it will be searched in the 
        /// Response, otherwise an empty string will be returned
        /// </summary>
        /// <param name="httpContextAccesor"></param>
        /// <param name="headerKey"></param>
        /// <returns></returns>
        internal static string getHeaderValue(this IHttpContextAccessor httpContextAccesor, string headerKey)
        {
            var header = string.Empty;

            if (httpContextAccesor.HttpContext.Request.Headers.TryGetValue(headerKey, out var values))
            {
                header = values.FirstOrDefault();
            }
            else if (httpContextAccesor.HttpContext.Response.Headers.TryGetValue(headerKey, out values))
            {
                header = values.FirstOrDefault();
            }

            return header;
        }
    }
}
