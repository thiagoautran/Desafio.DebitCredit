using Account.ApplicationCore.Entities;
using Account.ApplicationCore.Exceptions;
using Account.ApplicationCore.Interfaces;

namespace Account.Infrastructure.Data
{
    public class TransactionRepository : EFRepository, ITransactionRepository
    {
        public TransactionRepository(IEFContext dbContext) : base(dbContext) { }

        public async Task Insert(TransactionEntity transaction)
        {
            try
            {
                await _dbContext.Set<TransactionEntity>().AddAsync(transaction);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new EfEntityException(ex, transaction);
            }
        }
    }
}