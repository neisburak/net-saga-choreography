using MassTransit;
using MessageContracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.Consumers;

namespace PaymentService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(configuration =>
            {
                configuration.AddConsumer<StockReservedEventConsumer>();

                configuration.UsingRabbitMq((context, config) =>
                {
                    config.Host(RabbitMQConstants.Uri);

                    config.ReceiveEndpoint(RabbitMQConstants.PaymentStockReservedQueue, e =>
                    {
                        e.Consumer<StockReservedEventConsumer>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) { }
    }
}
