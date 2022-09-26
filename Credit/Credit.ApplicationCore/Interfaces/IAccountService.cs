using Credit.ApplicationCore.Entities;

namespace Credit.ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        Task Credit(uint agency, uint accountNumber, uint currentAccountDigit, TransactionEntity transaction);
    }
}