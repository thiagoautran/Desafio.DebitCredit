using Account.ApplicationCore.DTOs.Response.Report;
using Account.ApplicationCore.Entities;
using Account.ApplicationCore.Exceptions;
using Account.ApplicationCore.Interfaces;

namespace Account.ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        private readonly Guid _credit = Guid.Parse("c4a126a2-332e-44f0-9c9e-78a9a6287b39");
        private readonly Guid _debit = Guid.Parse("337de2d3-7c8a-4ce1-9111-659030be2ce6");

        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository) =>
            (_accountRepository, _transactionRepository) = (accountRepository, transactionRepository);

        public async Task<IEnumerable<AccountEntity>> Find() =>
            await _accountRepository.Find();

        public async Task<AccountEntity?> FindById(Guid id)
        {
            var account = await _accountRepository.FindById(id);
            if (account == null)
                throw new NotFoundException();

            return account;
        }

        public async Task Debit(TransactionEntity transaction)
        {
            var account = await _accountRepository.FindById(transaction.AccountId);
            if (account == null)
                throw new NotFoundException();

            transaction.OperationId = _debit;
            account.Balance -= transaction.Value;

            await _transactionRepository.Insert(transaction);
            await _accountRepository.Update(account);
        }

        public async Task Credit(TransactionEntity transaction)
        {
            var account = await _accountRepository.FindById(transaction.AccountId);
            if (account == null)
                throw new NotFoundException();

            transaction.OperationId = _credit;
            account.Balance += transaction.Value;

            await _transactionRepository.Insert(transaction);
            await _accountRepository.Update(account);
        }

        public async Task<BalanceResponse> Balance()
        {
            var amount = await _accountRepository.Balance();

            return new BalanceResponse 
            { 
                Amount = amount 
            };
        }
    }
}