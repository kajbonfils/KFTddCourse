using System;
using Moq;
using SingleResponsibilityViolation;
using SingleResponsibilityViolation.Service;
using Xunit;

namespace SingleResponsibilityDependencyViolationTest
{
    public class BankAccount2Test
    {
        private Mock<IBankServiceMapper> mapper;
        private Mock<IBankService> bankService;
        private BankAccount2 target;
        private Mock<IExcep> excep;

        public BankAccount2Test()
        {
            
            mapper = new Mock<IBankServiceMapper>();
            mapper.Setup(p => p.MapGetBalanceResponse(It.IsAny<GetBalanceResponse>())).Returns(10000);

            bankService = new Mock<IBankService>();

            excep = new Mock<IExcep>();

            target = new BankAccount2(bankService.Object, mapper.Object, excep.Object);
        }

        [Fact]
        public void WithdrawMoney_CallsMapGetBalanceRequestWithCorrectCpr()
        {
            target.Cprnummer = "1231231234";

            target.WithdrawMoney(1000);

            mapper.Verify(p=>p.MapGetBalanceRequest("1231231234"), Times.Once());
        }

        [Fact]
        public void WithdrawMoney_CallsBankserviceWithResultFromMapper()
        {

            var expected = new GetBalanceRequest();
            
            mapper.Setup(p=>p.MapGetBalanceRequest(It.IsAny<string>())).Returns(expected);

            target.WithdrawMoney(10000);

            bankService.Verify(p=>p.GetBalance(expected),Times.Once());
        }

        [Fact]
        public void WithdrawMoney_CallsMapperWithResultFromBankService()
        {
            var expected = new GetBalanceResponse();

            bankService.Setup(p=>p.GetBalance(It.IsAny<GetBalanceRequest>())).Returns(expected);

            target.WithdrawMoney(10000);

            mapper.Verify(p=>p.MapGetBalanceResponse(expected), Times.Once());
        }

        [Fact]
        public void WithdrawMoney_BalanceAfterWithdrawalNegative_ThrowsException()
        {
            mapper.Setup(p=>p.MapGetBalanceResponse(It.IsAny<GetBalanceResponse>())).Returns(10000);
            Assert.Throws<ArgumentException>(() => target.WithdrawMoney(20000));
        }

        [Fact]
        public void WithdrawMoney_BalanceIsPositive_CallsMapWithdrawRequest()
        {
            target.Cprnummer = "12312312324";
            target.WithdrawMoney(5000);

            mapper.Verify(p=>p.MapWithdrawRequest("12312312324", 5000), Times.Once());
        }

        [Fact]
        public void WithdrawMoney_BalanceIsPositive_CallsWithdrawMoneyOnBankService()
        {
            var expectedRequest = new WithdrawRequest();
            mapper.Setup(p=>p.MapWithdrawRequest(It.IsAny<string>(), It.IsAny<decimal>())).Returns(expectedRequest);

            target.WithdrawMoney(1000);

            bankService.Verify(p=>p.Withdraw(expectedRequest), Times.Once());
        }

        [Fact]
        public void WithdrawMoney_BalanceIsPositive_ReturnsNewBalance()
        {
            var actual = target.WithdrawMoney(2000);

            Assert.Equal(8000, actual);
        }
    }
}