using System;

namespace SingleResponsibilityViolation.Service
{
    public class BankService : IBankService
    {
        public GetBalanceResponse GetBalance(GetBalanceRequest balanceRequest)
        {
            var random = new Random();
            return new GetBalanceResponse()
            {
                Balance = random.Next(0, 100000)
            };
        }

        public void Withdraw(WithdrawRequest withdrawRequest)
        {
        }
    }
}