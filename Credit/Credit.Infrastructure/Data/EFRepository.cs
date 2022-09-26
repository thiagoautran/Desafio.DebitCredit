using Credit.ApplicationCore.Interfaces;

namespace Credit.Infrastructure.Data
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