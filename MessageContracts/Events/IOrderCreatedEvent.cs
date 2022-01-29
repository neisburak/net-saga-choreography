using System.Collections.Generic;

namespace MessageContracts.Events
{
    public interface IOrderCreatedEvent
    {
        int UserId { get; }
        int OrderId { get; }
        decimal TotalAmount { get; }
        List<IOrderItem> Items { get; }
    }
}