namespace MessageContracts.Events
{
    public interface IStockNotReservedEvent
    {
        int OrderId { get; }
        string Message { get; }
    }
}