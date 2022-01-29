using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Events;

namespace OrderService.Consumers
{
    public class PaymentConfirmedEventConsumer : IConsumer<IPaymentConfirmedEvent>
    {
        public Task Consume(ConsumeContext<IPaymentConfirmedEvent> context)
        {
            // Update order status to Confirmed from Pending via {context.Message.OrderId}

            return Task.CompletedTask;
        }
    }
}