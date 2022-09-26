using Credit.ApplicationCore.Entities;

namespace Credit.ApplicationCore.Interfaces
{
    public interface ITransactionRepository
    {
        Task Insert(TransactionEntity transaction);
    }
}