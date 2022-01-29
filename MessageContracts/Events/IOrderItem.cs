namespace MessageContracts.Events
{
    public interface IOrderItem
    {
        int Id { get; }
        int Quantity { get; }
    }
}