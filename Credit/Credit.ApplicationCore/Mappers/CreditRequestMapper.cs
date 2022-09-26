using Credit.ApplicationCore.DTOs.Request.Account;
using Credit.ApplicationCore.Entities;

namespace Credit.ApplicationCore.Mappers
{
    public static class CreditRequestMapper
    {
        public static TransactionEntity ToTransaction(this CreditRequest credit)
        {
            return new TransactionEntity
            {
                Date = DateTime.Now,
                Value = credit.Value
            };
        }
    }
}