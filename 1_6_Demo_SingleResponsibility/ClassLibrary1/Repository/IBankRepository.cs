namespace SingleResponsibilityViolation.Repository
{
    public interface IBankRepository
    {
        decimal GetBalance(string ssn);
        void Withdraw(string ssn, decimal amount);
    }
}