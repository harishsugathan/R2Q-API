namespace R2Q.Healthcheck
{
    public class DaprHealthCheck : IHealthCheck
    {
        private readonly DaprClient _daprClient;

        public DaprHealthCheck(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var healthy = await _daprClient.CheckHealthAsync(cancellationToken);

            if (healthy)
            {
                return HealthCheckResult.Healthy("Dapr sidecar is healthy.");
            }
            return HealthCheckResult.Unhealthy("Dapr sidecar is unhealthy.");
        }
    }
}
