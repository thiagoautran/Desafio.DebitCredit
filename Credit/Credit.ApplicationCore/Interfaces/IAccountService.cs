using Credit.ApplicationCore.Entities;

namespace Credit.ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        Task Credit(int agency, int accountNumber, int currentAccountDigit, TransactionEntity transaction);
    }
}