using System;
using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityViolation.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly BankService _bankService;
        private readonly Mapper _mapper;

        public BankRepository(BankService bankService, Mapper mapper)
        {
            _bankService = bankService;
            _mapper = mapper;
        }

        public decimal GetBalance(string ssn)
        {
            // Maps the request to get the balance
            var balanceRequest = _mapper.MapGetBalanceRequest(ssn);

            //  Calls the bankService
            var balanceResponse = _bankService.GetBalance(balanceRequest);

            // Maps the response
            return _mapper.MapGetBalanceResponse(balanceResponse);
        }

        public void Withdraw(string ssn, decimal amount)
        {
            var withdrawRequest = _mapper.MapWithdrawRequest(ssn, amount);
            _bankService.Withdraw(withdrawRequest);
        }
    }
}