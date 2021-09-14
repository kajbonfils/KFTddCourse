namespace SingleResponsibilityViolation.Service
{
    public interface IBankService
    {
        void Withdraw(WithdrawRequest withdrawRequest);
        GetBalanceResponse GetBalance(GetBalanceRequest balanceRequest);
    }
}