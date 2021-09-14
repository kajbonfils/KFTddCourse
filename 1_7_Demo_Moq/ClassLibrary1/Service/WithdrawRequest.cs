namespace SingleResponsibilityViolation.Service
{
    public class WithdrawRequest
    {
        public string CprNummer { get; set; }
        public decimal WithdrawAmount { get; set; }
    }
}