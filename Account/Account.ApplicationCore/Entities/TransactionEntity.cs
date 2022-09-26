namespace Account.ApplicationCore.Entities
{
    public class TransactionEntity
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Guid AccountId { get; set; }
        public Guid OperationId { get; set; }
    }
}