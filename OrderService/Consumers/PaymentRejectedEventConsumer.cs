using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Events;

namespace OrderService.Consumers
{
    public class PaymentRejectedEventConsumer : IConsumer<IPaymentRejectedEvent>
    {
        public Task Consume(ConsumeContext<IPaymentRejectedEvent> context)
        {
            // Update order status to Rejected from Pending via {context.Message.OrderId}

            return Task.CompletedTask;
        }
    }
}