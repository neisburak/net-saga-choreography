using MessageContracts;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace OrderService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(configuration =>
            {
                configuration.AddConsumer<CreateOrderCommandConsumer>();
                configuration.AddConsumer<StockNotReservedEventConsumer>();
                configuration.AddConsumer<PaymentConfirmedEventConsumer>();
                configuration.AddConsumer<PaymentRejectedEventConsumer>();

                configuration.UsingRabbitMq((context, config) =>
                {
                    config.Host(RabbitMQConstants.Uri);

                    config.ReceiveEndpoint(RabbitMQConstants.CreateOrderQueueName, e =>
                    {
                        e.Consumer<CreateOrderCommandConsumer>(context);
                    });

                    config.ReceiveEndpoint(RabbitMQConstants.OrderStockNotReservedQueueName, e =>
                    {
                        e.Consumer<StockNotReservedEventConsumer>(context);
                    });

                    config.ReceiveEndpoint(RabbitMQConstants.PaymentConfirmedQueueName, e =>
                    {
                        e.Consumer<PaymentConfirmedEventConsumer>(context);
                    });

                    config.ReceiveEndpoint(RabbitMQConstants.OrderPaymentRejectedQueueName, e =>
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

