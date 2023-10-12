using OpenTracing;

namespace R2Q.Service1.Api.Middleware
{
    public class JaegerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ITracer tracer;

        public JaegerMiddleware(RequestDelegate next, ITracer tracer)
        {
            this.next = next;
            this.tracer = tracer;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var spanBuilder = tracer.BuildSpan(context.Request.Path);
            var spanContext = spanBuilder.StartActive();
            var span = spanContext.Span;

            try
            {
                await next(context);
            }
            finally
            {
                span.Finish();
            }
        }
    }
}
