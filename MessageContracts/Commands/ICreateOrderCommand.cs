using System.Collections.Generic;

namespace MessageContracts.Commands
{
    public interface ICreateOrderCommand
    {
        int UserId { get; }
        List<IOrderItem> Items { get; }
    }

    public interface IOrderItem
    {
        int ProductId { get; }
        int Quantity { get; }
        decimal Price { get; }
    }
}