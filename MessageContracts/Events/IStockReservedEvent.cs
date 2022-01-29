using System.Collections.Generic;

namespace MessageContracts.Events
{
    public interface IStockReservedEvent
    {
        int UserId { get; }
        int OrderId { get; }
        decimal TotalAmount { get; }
        List<IOrderItem> Items { get; }
    }
}