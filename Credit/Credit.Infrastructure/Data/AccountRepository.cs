using Credit.ApplicationCore.Entities;
using Credit.ApplicationCore.Exceptions;
using Credit.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit.Infrastructure.Data
{
    public class AccountRepository : EFRepository, IAccountRepository
    {
        public AccountRepository(IEFContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<AccountEntity>> Find() =>
            await _dbContext.Set<AccountEntity>().ToListAsync();

        public async Task<AccountEntity?> Find(int agency, int accountNumber, int currentAccountDigit)
        {
            var query = _dbContext.Set<AccountEntity>()
                .Where(account => 
                    account.Agency == agency &&
                    account.AccountNumber == accountNumber &&
                    account.CurrentAccountDigit == currentAccountDigit);

            try
            {
                return await query.FirstOrDefaultAsync();
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