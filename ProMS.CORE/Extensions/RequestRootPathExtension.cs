using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Extensions
{
    public static class RequestRootPathExtension
    {
        /// <summary>
        /// Get root path URL
        /// </summary>
        /// <param name="request"></param>
        /// <param name="addPath"></param>
        /// <param name="addQuery"></param>
        /// <returns></returns>
        public static Uri GetRootUri(this HttpRequest request, bool addPath = true, bool addQuery = true)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = request.Scheme,
                Host = request.Host.Host,
                Port = request.Host.Port.GetValueOrDefault(80),
                Path = addPath ? request.Path.ToString() : default,
                Query = addQuery ? request.QueryString.ToString() : default
            };
            return uriBuilder.Uri;
        }
    }
}
