using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Events;

namespace PaymentService.Consumers
{
    public class StockReservedEventConsumer : IConsumer<IStockReservedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public StockReservedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<IStockReservedEvent> context)
        {
            var message = context.Message;

            var paymentResult = false;

            if (paymentResult)
            {
                await _publishEndpoint.Publish<IPaymentConfirmedEvent>(new
                {
                    OrderId = message.OrderId
                });
            }
            else
            {
                await _publishEndpoint.Publish<IPaymentRejectedEvent>(new
                {
                    UserId = message.UserId,
                    OrderId = message.OrderId,
                    Items = message.Items,
                    Message = "Payment rejected."
                });
            }
        }
    }
}