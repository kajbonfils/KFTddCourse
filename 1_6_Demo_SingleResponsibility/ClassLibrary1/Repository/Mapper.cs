using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityViolation.Repository
{
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
}