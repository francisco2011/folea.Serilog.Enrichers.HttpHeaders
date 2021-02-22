using folea.Serilog.Enrichers.HttpHeaders.Extensions;
using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System;


namespace folea.Serilog.Enrichers.HttpHeaders.Implementations
{
    public class HttpHeaderEnricher : ILogEventEnricher
    {

        private Tuple<string, string>[] HeaderKeys { get; }
        private IHttpContextAccessor HttpContextAccessor { get; }

        /// <summary>
        /// header keys is composed by header key and log property name
        /// if log property is not suplied then the header name will be used
        /// </summary>
        /// <param name="headerKeys">header key -log property name</param>
        public HttpHeaderEnricher(Tuple<string, string>[] headerKeys)
        {
            this.HeaderKeys = headerKeys;
            this.HttpContextAccessor = new HttpContextAccessor();
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (HttpContextAccessor.HttpContext is null) return; 
            if (HeaderKeys is null || HeaderKeys.Length == 0) return;

            for (int i = 0; i < HeaderKeys.Length; i++)
            {
                var tup = HeaderKeys[i];

                if (string.IsNullOrEmpty(tup.Item1)) continue;

                var headerValue = this.HttpContextAccessor.getHeaderValue(tup.Item1);

                var correlationIdProperty = new LogEventProperty(string.IsNullOrEmpty(tup.Item2) ? tup.Item1 : tup.Item2, new ScalarValue(headerValue));

                logEvent.AddOrUpdateProperty(correlationIdProperty);

            }
        }
    }
}
