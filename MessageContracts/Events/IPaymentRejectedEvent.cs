using System.Collections.Generic;

namespace MessageContracts.Events
{
    public interface IPaymentRejectedEvent
    {
        int UserId { get; }
        int OrderId { get; }
        List<IOrderItem> Items { get; }
        string Message { get; }
    }
}