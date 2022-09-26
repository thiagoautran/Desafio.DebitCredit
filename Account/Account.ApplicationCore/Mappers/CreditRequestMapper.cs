using Account.ApplicationCore.DTOs.Request.Account;
using Account.ApplicationCore.Entities;

namespace Account.ApplicationCore.Mappers
{
    public static class CreditRequestMapper
    {
        public static TransactionEntity ToTransaction(this CreditRequest credit, Guid accountId)
        {
            return new TransactionEntity
            {
                Date = DateTime.Now,
                Value = credit.Value,
                AccountId = accountId
            };
        }
    }
}