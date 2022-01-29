using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Events;

namespace StockService.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<IOrderCreatedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderCreatedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<IOrderCreatedEvent> context)
        {
            var message = context.Message;

            var stockResult = true;

            if (stockResult)
            {
                // Update stocks ...

                await _publishEndpoint.Publish<IStockReservedEvent>(new
                {
                    UserId = message.UserId,
                    OrderId = message.OrderId,
                    TotalAmount = message.TotalAmount,
                    Items = message.Items
                });
            }
            else
            {
                await _publishEndpoint.Publish<IStockNotReservedEvent>(new
                {
                    OrderId = message.OrderId,
                    Message = "Insufficient Stock"
                });
            }
        }
    }
}