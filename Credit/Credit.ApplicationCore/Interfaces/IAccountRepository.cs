using Credit.ApplicationCore.Entities;

namespace Credit.ApplicationCore.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountEntity?> Find(int agency, int accountNumber, int currentAccountDigit);
        Task Update(AccountEntity account);
    }
}