using Account.ApplicationCore.Entities;
using Account.ApplicationCore.Exceptions;
using Account.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Data
{
    public class AccountRepository : EFRepository, IAccountRepository
    {
        public AccountRepository(IEFContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<AccountEntity>> Find() =>
            await _dbContext.Set<AccountEntity>().ToListAsync();

        public async Task<AccountEntity?> FindById(Guid id)
        {
            var query = _dbContext.Set<AccountEntity>()
                .Where(account => account.Id == id);

            try
            {
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new EfQueryException(ex, query.ToQueryString());
            }
        }

        public async Task<decimal> Balance()
        {
            var query = _dbContext.Set<AccountEntity>()
                .Select(account => account.Balance);

            try
            {
                return await query.SumAsync();
            }
            catch (Exception ex)
            {
                throw new EfQueryException(ex, query.ToQueryString());
            }
        }

        public async Task Update(AccountEntity account)
        {
            try
            {
                _dbContext.Set<AccountEntity>().Update(account);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new EfEntityException(ex, account);
            }
        }
    }
}