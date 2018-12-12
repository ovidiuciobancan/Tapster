using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Utils.Threading
{
    public abstract class TimedHostedService : IHostedService, IDisposable
    {
        protected IServiceProvider Services;
        private Timer Timer;
        private readonly int Interval;

        public TimedHostedService(IServiceProvider services, int interval)
        {
            Services = services;
            Interval = interval;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Timer = new Timer(_DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(Interval));

            OnStart();

            return Task.CompletedTask;
        }
        protected abstract void OnStart();
        protected abstract Task DoWork(object state, IServiceProvider service);
        protected abstract void OnStop();
        private void _DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                 DoWork(state, scope.ServiceProvider).Wait();
            }
        }
        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            OnStop();

            Timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            Timer?.Dispose();
        }
    }
}