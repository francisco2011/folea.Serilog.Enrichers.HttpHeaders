# folea.Serilog.Enrichers.HttpHeaders
Simple to use Serilog Enricher that allows developers to select the headers they want to log and the name of the properties that will be used

Example

Just call it from Main inside Program.cs in your asp.net core project

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(_config).WriteTo.Console(new JsonFormatter())
                .Enrich.WithHttpHeaders(new Tuple<string, string>[2] { new Tuple<string, string>("request-id", "requestId"), 
                                                                        new Tuple<string, string>("event-id", "eventId"),
                                                                        new Typle<string, string>("another-header", "another-property") })
                .CreateLogger();
