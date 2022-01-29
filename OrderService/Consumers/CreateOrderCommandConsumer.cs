using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Commands;
using MessageContracts.Events;

namespace OrderService.Consumers
{
    public class CreateOrderCommandConsumer : IConsumer<ICreateOrderCommand>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateOrderCommandConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<ICreateOrderCommand> context)
        {
            var message = context.Message;

            // Some validation ...

            // Create order with Pending status

            await _publishEndpoint.Publish<IOrderCreatedEvent>(new
            {
                UserId = message.UserId,
                OrderId = 1,
                Items = message.Items.Select(s => new
                {
                    Id = s.ProductId,
                    Quantity = s.Quantity
                }),
                TotalAmount = message.Items.Sum(s => s.Quantity * s.Price)
            });
        }
    }
}