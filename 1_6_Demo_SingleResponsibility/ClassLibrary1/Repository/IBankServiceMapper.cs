using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityViolation.Repository
{
    public interface IBankServiceMapper
    {
        GetBalanceRequest MapGetBalanceRequest(string cprnummer);
        decimal MapGetBalanceResponse(GetBalanceResponse balanceResponse);
        WithdrawRequest MapWithdrawRequest(string cprnummer, decimal amount);
    }
}