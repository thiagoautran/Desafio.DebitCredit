using Account.ApplicationCore.Entities;

namespace Account.ApplicationCore.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AccountEntity>> Find();
        Task<AccountEntity?> FindById(Guid id);
        Task<decimal> Balance();
        Task Update(AccountEntity account);
    }
}