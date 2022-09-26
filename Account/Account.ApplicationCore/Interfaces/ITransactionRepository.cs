using Account.ApplicationCore.Entities;

namespace Account.ApplicationCore.Interfaces
{
    public interface ITransactionRepository
    {
        Task Insert(TransactionEntity transaction);
    }
}