using SingleResponsibilityViolation;
using SingleResponsibilityViolation.Repository;
using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityDependencyViolationTest
{
    public class MapperStub : IBankServiceMapper
    {

        public MapperStub()
        {
            MapGetBalanceRequestExpectedResult = new GetBalanceRequest();
            MapGetBalanceResponseExpectedResult = 10000;
            MapWithdrawRequestExpectedResult = new WithdrawRequest();
        }



        public GetBalanceRequest MapGetBalanceRequestExpectedResult { get; set; }
        public int MapGetBalanceRequestCalls { get; set; }
        public string MapGetBalanceRequestLastCprNummer { get; set; }

        public GetBalanceRequest MapGetBalanceRequest(string cprnummer)
        {
            MapGetBalanceRequestCalls ++;
            MapGetBalanceRequestLastCprNummer = cprnummer;
            
            return MapGetBalanceRequestExpectedResult;
        }


        public GetBalanceResponse MapGetBalanceResponseLastArgument { get; set; }
        public int MapGetBalanceResponseExpectedResult { get; set; }

        public decimal MapGetBalanceResponse(GetBalanceResponse balanceResponse)
        {
            MapGetBalanceResponseLastArgument = balanceResponse;
            return MapGetBalanceResponseExpectedResult;
        }




        public string MapWithdrawRequestLastCpr { get; set; }
        public decimal MapWithdrawRequestLastAmount { get; set; }
        public WithdrawRequest MapWithdrawRequestExpectedResult { get; set; }

        public WithdrawRequest MapWithdrawRequest(string cprnummer, decimal amount)
        {
            MapWithdrawRequestLastCpr = cprnummer;
            MapWithdrawRequestLastAmount = amount;
            return MapWithdrawRequestExpectedResult;
        }
    }
}