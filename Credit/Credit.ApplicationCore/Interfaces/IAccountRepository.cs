using Credit.ApplicationCore.Entities;

namespace Credit.ApplicationCore.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountEntity?> Find(uint agency, uint accountNumber, uint currentAccountDigit);
        Task Update(AccountEntity account);
    }
}