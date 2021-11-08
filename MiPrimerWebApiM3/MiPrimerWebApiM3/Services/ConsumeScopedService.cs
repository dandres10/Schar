namespace MiPrimerWebApiM3.Services
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MiPrimerWebApiM3.Contexts;
    using MiPrimerWebApiM3.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ConsumeScopedService : IHostedService, IDisposable
    {
        private Timer timer;
        public IServiceProvider Services { get; }

        public ConsumeScopedService(IServiceProvider service)
        {
            Services = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var message = "ConsumeScopedService. Received message at " + DateTime.Now.ToString();
                var log = new HostedServiceLog { Message = message };
                context.HostedServiceLogs.Add(log);
                context.SaveChanges();
            }
        }

        

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}