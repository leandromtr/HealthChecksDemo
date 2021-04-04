using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.HealthChecks
{
    public class ResponseTimeHealthCheck : IHealthCheck
    {
        private Random rdn = new Random();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int responseTimeInMs = rdn.Next(1, 300);
            if (responseTimeInMs < 100)
            {
                return Task.FromResult(HealthCheckResult.Healthy($"The response time looks good ({ responseTimeInMs }ms)."));
            }
            else if (responseTimeInMs < 200)
            {
                return Task.FromResult(HealthCheckResult.Degraded($"The response time is a bit slow ({ responseTimeInMs }ms)."));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy($"The response time is unacceptable ({ responseTimeInMs }ms)."));
            }
        }
    }
}
