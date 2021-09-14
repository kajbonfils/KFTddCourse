using SingleResponsibilityViolation.Repository;
using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityDependencyViolationTest
{
    public class BankRepositoryStub  : IBankRepository
    {
        public decimal GetBalanceResult { private get; set; }
        public string GetBalanceSsnArgument { get; private set; }
        public decimal GetBalance(string ssn)
        {
            GetBalanceSsnArgument = ssn;
            return GetBalanceResult;
        }


        public string WithDrawSssnArgument { get; private set; }
        public decimal WithDrawAmountArgument { get; private set; }

        public void Withdraw(string ssn, decimal amount)
        {
            WithDrawSssnArgument = ssn;
            WithDrawAmountArgument = amount;
        }

    }
    
    
    public class BankServiceStub : IBankService
    {
        public BankServiceStub()
        {
            GetBalanceExpectedResult = new GetBalanceResponse();
        }

        public WithdrawRequest WithdrawLastArgument { get; set; }
        public void Withdraw(WithdrawRequest withdrawRequest)
        {
            WithdrawLastArgument = withdrawRequest;
        }

        public GetBalanceResponse GetBalanceExpectedResult { get; set; }
        public GetBalanceRequest GetBalanceLastRequest { get; set; }

        public GetBalanceResponse GetBalance(GetBalanceRequest balanceRequest)
        {
            GetBalanceLastRequest = balanceRequest;
            return GetBalanceExpectedResult;
        }

    }
}