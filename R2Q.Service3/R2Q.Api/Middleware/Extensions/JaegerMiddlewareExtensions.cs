using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using Jaeger;
using OpenTracing.Util;
using OpenTracing;

namespace R2Q.Service1.Api.Middleware.Extensions
{
    public static class JaegerMiddlewareExtensions
    {
        public static IServiceCollection AddJaegerTracing(this IServiceCollection services)
        {
            services.AddSingleton<ITracer>(serviceProvider =>
            {
                var serviceName = serviceProvider.GetRequiredService<IWebHostEnvironment>().ApplicationName;
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                var reporter = new RemoteReporter.Builder().WithLoggerFactory(loggerFactory).WithSender(new UdpSender())
                    .Build();
                var tracer = new Tracer.Builder(serviceName)
                    // The constant sampler reports every span.
                    .WithSampler(new ConstSampler(true))
                    // LoggingReporter prints every reported span to the logging framework.
                    .WithReporter(reporter)
                    .Build();

                GlobalTracer.Register(tracer);
               
                return tracer;
            });

            return services;
        }

        public static IApplicationBuilder UseJaegerTracing(this IApplicationBuilder app)
        {
            app.UseMiddleware<JaegerMiddleware>();
            return app;
        }
    }
}
