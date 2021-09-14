using System;
using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityViolation
{
    public class BankAccount
    {
        public string Cprnummer { get; private set; }

        public decimal WithdrawMoney(decimal amount)
        {
            // Creates an instance of the bankService.
            var bankService = new BankService();
            
            // Maps the request to get the balance
            var balanceRequest = new GetBalanceRequest()
            {
                Cprnummer = this.Cprnummer
            };

            //  Calls the bankService
            var balanceResponse = bankService.GetBalance(balanceRequest);
            
            // Maps the response
            var balance = balanceResponse.Balance;
            
            // Do the actual business logic we require
            var balanceAfterWithdrawal = balance - amount;
            if (balanceAfterWithdrawal < 0)
                throw new ArgumentException("Amount is larger than current balance.");

            // Maps another request
            var withdrawRequest = new WithdrawRequest()
            {
                CprNummer = this.Cprnummer,
                WithdrawAmount = amount
            };
            // Calls the service again
            bankService.Withdraw(withdrawRequest);

            return balanceAfterWithdrawal;
        }

    }
}
