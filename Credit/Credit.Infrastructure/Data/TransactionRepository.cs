using Credit.ApplicationCore.Entities;
using Credit.ApplicationCore.Exceptions;
using Credit.ApplicationCore.Interfaces;

namespace Credit.Infrastructure.Data
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