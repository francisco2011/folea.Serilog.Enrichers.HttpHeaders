using folea.Serilog.Enrichers.HttpHeaders.Implementations;
using Serilog;
using Serilog.Configuration;
using System;

namespace folea.Serilog.Enrichers.HttpHeaders.Extensions
{
    
        public static class HttpHeaderEnricherExtensions
    {
            /// <summary>
            /// header keys is composed by header key and log property name
            /// if log property is not suplied then the header name will be used
            /// </summary>
            /// <param name="headerKeys">header key -log property name</param>
            /// <returns></returns>
            public static LoggerConfiguration WithHttpHeaders(
                this LoggerEnrichmentConfiguration enrichmentConfiguration,
                Tuple<string, string>[] headerKeys)
            {
                if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
                return enrichmentConfiguration.With(new HttpHeaderEnricher(headerKeys));
            }
        }
    
}
