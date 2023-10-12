using R2Q.Healthcheck;

namespace Microsoft.Extensions.DependencyInjection;

public static class DaprHealthCheckBuilderExtensions
{
    public static IHealthChecksBuilder AddDaprHealthCheck(this IHealthChecksBuilder builder) =>
        builder.AddCheck<DaprHealthCheck>("dapr");
}
