using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Application.Requests.HealthCheck
{
    public class HeartbeatsQuery : IRequest<string>
    {
        private CancellationTokenSource canceller = new CancellationTokenSource();
        private Task monitor;

        private bool dead = false;

        public async Task HeartBeatReceived()
        {
            if (dead)
            {
                Console.WriteLine("dead people dont have heartbeats");
                canceller.Cancel();
                return;
            }
            Console.WriteLine("heartbeat");
            canceller.Cancel();

            canceller = new CancellationTokenSource();
            monitor = Task.Delay(TimeSpan.FromSeconds(5), canceller.Token).ContinueWith((t) =>
            {
                if (!t.IsCanceled)
                {
                    Console.WriteLine("missed!");
                    dead = true;
                }

            });
        }
    }
}
