namespace Account.ApplicationCore.Entities
{
    public class AccountEntity
    {
        public Guid Id { get; set; }
        public int Agency { get; set; }
        public int AccountNumber { get; set; }
        public int CurrentAccountDigit { get; set; }
        public decimal Balance { get; set; }
        public Guid PersonId { get; set; }
    }
}