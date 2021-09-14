using System;
using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityViolation
{
    public class BankAccount2
    {
        private readonly IBankService _bankService;
        private readonly IBankServiceMapper _mapper;
        private readonly IExcep excep;
        public string Cprnummer { get; set; }

        public BankAccount2(IBankService bankService, IBankServiceMapper mapper, IExcep excep)
        {
            _bankService = bankService;
            _mapper = mapper;
            this.excep = excep;
        }

        public BankAccount2()
        {
            _bankService = new BankService();
            _mapper = new Mapper();
        }

        public decimal WithdrawMoney(decimal amount)
        {
            // Maps the request to get the balance
            var balanceRequest = _mapper.MapGetBalanceRequest(this.Cprnummer);

            ////  Calls the bankService
            var balanceResponse = _bankService.GetBalance(balanceRequest);

            // Maps the response
            var balance = _mapper.MapGetBalanceResponse(balanceResponse);

            // Do the actual business logic we require
            var balanceAfterWithdrawal = balance - amount;
            if (balanceAfterWithdrawal < 0)
                throw new ArgumentException("Amount is larger than current balance.");

            // Maps another request
            var withdrawRequest = _mapper.MapWithdrawRequest(Cprnummer, amount);

            // Calls the service again
            _bankService.Withdraw(withdrawRequest);

            return balanceAfterWithdrawal;
        }

        
        public int DoStuff()
        {
            try
            {
                excep.DoStuff();
            }
            catch (ApplicationException ex) { return 444; }

            return 0;
        }

    }

    public interface IExcep
    {
        void DoStuff();
    }

    public class Mapper : IBankServiceMapper
    {
        public GetBalanceRequest MapGetBalanceRequest(string cprnummer)
        {
            return new GetBalanceRequest {Cprnummer = cprnummer};
        }

        public decimal MapGetBalanceResponse(GetBalanceResponse balanceResponse)
        {
            return balanceResponse.Balance;
        }

        public WithdrawRequest MapWithdrawRequest(string cprnummer, decimal amount)
        {
            return new WithdrawRequest {CprNummer = cprnummer, WithdrawAmount = amount};
        }
    }

    public interface IBankServiceMapper
    {
        GetBalanceRequest MapGetBalanceRequest(string cprnummer);
        decimal MapGetBalanceResponse(GetBalanceResponse balanceResponse);
        WithdrawRequest MapWithdrawRequest(string cprnummer, decimal amount);
    }
}
