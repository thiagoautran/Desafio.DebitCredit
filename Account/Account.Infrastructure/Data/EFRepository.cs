using Account.ApplicationCore.Interfaces;

namespace Account.Infrastructure.Data
{
    public class EFRepository
    {
        protected readonly IEFContext _dbContext;

        public EFRepository(IEFContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}