namespace IHostedServiceDemo.Services
{
    using Microsoft.Extensions.Hosting;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class WriteToFileHostedService2 : IHostedService, IDisposable
    {
        private readonly IHostEnvironment environment;
        private readonly string fileName = "File 2.txt";
        private Timer timer;

        public WriteToFileHostedService2(IHostEnvironment environment)
        {
            this.environment = environment;
        }

        private void DoWork(object state)
        {
            WriteToFile("WriteToFileHostedService: Doing some work at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile("WriteToFileHostedService: Process Started");
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(7)); //activar el timer
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("WriteToFileHostedService: Process Stopped");
            timer?.Change(Timeout.Infinite, 0); //desactivar el timer 
            return Task.CompletedTask;
        }

        private void WriteToFile(string message)
        {
            var path = $@"{ environment.ContentRootPath }\wwwroot\{fileName}";
            using (StreamWriter write = new StreamWriter(path, append: true))
            {
                write.WriteLine(message);
            }
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}