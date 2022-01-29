namespace MessageContracts
{
    public class RabbitMQConstants
    {
        public const string Uri = "amqp://localhost";
        public const string Username = "guest";
        public const string Password = "guest";

        public const string CreateOrderQueueName = "order.create";
        public const string StockOrderCreatedQueueName = "order.created";
        public const string OrderStockNotReservedQueueName = "order.stock.insufficent";
        public const string PaymentStockReservedQueue = "stock.reserved";
        public const string StockPaymentRejectedQueueName = "stock.payment.rejected";
        public const string PaymentConfirmedQueueName = "payment.confirmed";
        public const string OrderPaymentRejectedQueueName = "order.payment.rejected";
    }
}