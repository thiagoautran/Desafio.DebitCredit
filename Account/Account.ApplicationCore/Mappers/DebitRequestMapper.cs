using Account.ApplicationCore.DTOs.Request.Account;
using Account.ApplicationCore.Entities;

namespace Account.ApplicationCore.Mappers
{
    public static class DebitRequestMapper
    {
        public static TransactionEntity ToTransaction(this DebitRequest debit, Guid accountId)
        {
            return new TransactionEntity
            {
                Date = DateTime.Now,
                Value = debit.Value,
                AccountId = accountId
            };
        }
    }
}