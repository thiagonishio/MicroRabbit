using Confluent.Kafka;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var conf = new ConsumerConfig
            //{
            //    GroupId = "test-consumer-group",
            //    BootstrapServers = "localhost:9092",
            //    AutoOffsetReset = AutoOffsetReset.Earliest
            //};

            //using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            //{
            //    c.Subscribe(typeof(TransferCreatedEvent).Name);
            //    var cts = new CancellationTokenSource();

            //    try
            //    {
            //        while (true)
            //        {
            //            var message = c.Consume(cts.Token);
            //            var log = $"Mensagem: {message.Message.Value} recebida de {message.TopicPartitionOffset}";
            //            _logger.LogInformation(log);
            //            Console.WriteLine(log);
            //        }
            //    }
            //    catch (OperationCanceledException)
            //    {
            //        c.Close();
            //    }
            //}

            _bus.Subscribe<TransferCreatedEvent, TransferEventHandler>();


            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}