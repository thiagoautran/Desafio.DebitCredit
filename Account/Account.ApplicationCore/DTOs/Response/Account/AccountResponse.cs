namespace Account.ApplicationCore.DTOs.Response.Account
{
    public class AccountResponse
    {
        public Guid Id { get; set; }
        public int Agency { get; set; }
        public int AccountNumber { get; set; }
        public int CurrentAccountDigit { get; set; }
        public decimal Balance { get; set; }
    }
}