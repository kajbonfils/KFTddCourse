using System;
using SingleResponsibilityViolation.Repository;
using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityViolation
{
    public class BankAccount2
    {
        private readonly IBankRepository _bankRepository;
        public string Cprnummer { get; set; }

        public BankAccount2(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public BankAccount2()
        {
            _bankRepository = new BankRepository(new BankService(), new Mapper());
        }

        public decimal WithdrawMoney(decimal amount)
        {

            var balance = _bankRepository.GetBalance(this.Cprnummer);

            // Do the actual business logic we require
            var balanceAfterWithdrawal = balance - amount;
            if (balanceAfterWithdrawal < 0)
                throw new ArgumentException("Amount is larger than current balance.");

            _bankRepository.Withdraw(this.Cprnummer, amount);

            return balanceAfterWithdrawal;
        }

    }
}
