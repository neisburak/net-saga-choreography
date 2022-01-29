using System.Threading.Tasks;
using MassTransit;
using MessageContracts.Events;

namespace StockService.Consumers
{
    public class PaymentRejectedEventConsumer : IConsumer<IPaymentRejectedEvent>
    {
        public Task Consume(ConsumeContext<IPaymentRejectedEvent> context)
        {
            // Update stocks with compensable transaction to back

            return Task.CompletedTask;
        }
    }
}