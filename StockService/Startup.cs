using MassTransit;
using MessageContracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StockService.Consumers;

namespace StockService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(configuration =>
            {
                configuration.AddConsumer<OrderCreatedEventConsumer>();
                configuration.AddConsumer<PaymentRejectedEventConsumer>();

                configuration.UsingRabbitMq((context, config) =>
                {
                    config.Host(RabbitMQConstants.Uri);

                    config.ReceiveEndpoint(RabbitMQConstants.StockOrderCreatedQueueName, e =>
                    {
                        e.Consumer<OrderCreatedEventConsumer>(context);
                    });

                    config.ReceiveEndpoint(RabbitMQConstants.StockPaymentRejectedQueueName, e =>
                    {
                        e.Consumer<PaymentRejectedEventConsumer>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) { }
    }
}
