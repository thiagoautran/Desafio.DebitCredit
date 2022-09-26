using Account.ApplicationCore.DTOs.Response.Account;
using Account.ApplicationCore.Entities;

namespace Account.ApplicationCore.Mappers
{
    public static class AccountMapper
    {
        public static IEnumerable<AccountResponse> ToAccountResponse(this IEnumerable<AccountEntity> accounts)
        {
            var list = new List<AccountResponse>();

            foreach (var account in accounts)
            {
                list.Add(account.ToAccountResponse());
            }

            return list;
        }

        public static AccountResponse ToAccountResponse(this AccountEntity account)
        {
            return new AccountResponse
            {
                Id = account.Id,
                Agency = account.Agency,
                AccountNumber = account.AccountNumber,
                CurrentAccountDigit = account.CurrentAccountDigit,
                Balance = account.Balance
            };
        }
    }
}