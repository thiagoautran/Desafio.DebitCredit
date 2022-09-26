using Credit.ApplicationCore.Entities;
using Credit.ApplicationCore.Exceptions;
using Credit.ApplicationCore.Interfaces;

namespace Credit.ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        private readonly Guid _credit = Guid.Parse("c4a126a2-332e-44f0-9c9e-78a9a6287b39");

        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository) =>
            (_accountRepository, _transactionRepository) = (accountRepository, transactionRepository);

        public async Task Credit(int agency, int accountNumber, int currentAccountDigit, TransactionEntity transaction)
        {
            var account = await _accountRepository.Find(agency, accountNumber, currentAccountDigit);
            if (account == null)
                throw new NotFoundException();

            transaction.AccountId = account.Id;
            transaction.OperationId = _credit;
            account.Balance += transaction.Value;

            await _transactionRepository.Insert(transaction);
            await _accountRepository.Update(account);
        }
    }
}