using System;
using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityViolation
{
    public class BankAccount
    {
        private readonly IBankService _bankService;
        private readonly IBankServiceMapper _mapper;
        public Customer Customer { get; set; }

        public BankAccount(IBankService bankService, IBankServiceMapper mapper)
        {
            _bankService = bankService;
            _mapper = mapper;
        }

        public BankAccount()
        {
            _bankService = new BankService();
            _mapper = new BankServiceMapper();
        }

        public decimal WithdrawMoney(decimal amount)
        {
            // Maps the request to get the balance
            var balanceRequest = _mapper.MapGetBalanceRequest(this.Customer.CprNummer);

            //  Calls the bankService
            var balanceResponse = _bankService.GetBalance(balanceRequest);
            
            // Maps the response
            var balance = _mapper.MapGetBalanceResponse(balanceResponse);
            
            // Do the actual business logic we require
            var balanceAfterWithdrawal = balance - amount;
            if (balanceAfterWithdrawal < 0)
                throw new ArgumentException("Amount is larger than current balance.");

            // Maps another request
            var withdrawRequest = _mapper.MapWithdrawRequest(Customer.CprNummer, amount);

            // Calls the service again
            _bankService.Withdraw(withdrawRequest);

            return balanceAfterWithdrawal;
        }
    }
}
