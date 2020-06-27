using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Api.Handler
{
    public class MessageHandler : IHostedService
    {
        private readonly IEventBus _bus;
        private readonly ILogger _logger;

        public MessageHandler(ILogger<MessageHandler> logger, IEventBus bus)
        {
            _bus = bus;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _bus.Subscribe<TransferCreatedEvent, TransferEventHandler>();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}