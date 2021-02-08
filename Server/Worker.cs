using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Internal;
using DomainModel;
using DomainModel.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Server
{
    public class Worker : IHostedService, IDisposable
    {
        private readonly IServiceProvider _services;
        private Timer _timer;

        public Worker(IServiceProvider services)
        {
            _services = services;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            _timer = new Timer(DoWork, null, TimeSpan.Zero, 
                TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            using var scope = _services.CreateScope();
            var repository = 
                scope.ServiceProvider
                    .GetRequiredService<IRepository<Vehicle>>();
            var vehicles = await repository.GetAllAsync();
            Random rng = new Random();
            vehicles.ForAll(v=>v.ShowStatus = rng.Next(0, 2) > 0);
            await repository.BeginTransactionAsync();
            repository.UpdateRange(vehicles);
            await repository.SaveChangesAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose() 
            => _timer?.Dispose();
    }
}