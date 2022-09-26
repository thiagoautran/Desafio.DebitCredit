using Account.ApplicationCore.DTOs.Response.Report;
using Account.ApplicationCore.Entities;

namespace Account.ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        Task<AccountEntity?> FindById(Guid id);
        Task<IEnumerable<AccountEntity>> Find();
        Task Debit(TransactionEntity transaction);
        Task Credit(TransactionEntity transaction);
        Task<BalanceResponse> Balance();
    }
}