using System;
using Moq;
using SingleResponsibilityViolation;
using SingleResponsibilityViolation.Service;
using Xunit;

namespace SingleResponsibilityDependencyViolationTest
{
    public class BankAccountTest
    {
        private Mock<IBankServiceMapper> mapper;
        private Mock<IBankService> bankService;
        private BankAccount target;
        private Customer customer;
        
        public BankAccountTest()
        {
            mapper = new Mock<IBankServiceMapper>();
            mapper.Setup(p => p.MapGetBalanceResponse(It.IsAny<GetBalanceResponse>())).Returns(10000);

            bankService = new Mock<IBankService>();

            target = new BankAccount(bankService.Object, mapper.Object);
            customer = new CustomerBuilder().Build();
            target.Customer = customer;
        }

        [Fact]
        public void WithdrawMoney_CallsMapGetBalanceRequestWithCorrectCpr()
        {
            target.Customer = new CustomerBuilder()
                .WithCpr("1231231234")
                .Build();

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
            target.Customer = new CustomerBuilder().WithCpr("12312312324").Build();
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

        [Fact]
        public void DoNothingButShowBuilder()
        {
            var customer = new CustomerBuilder()
                .WithFirstname("John")
                .WithLastname("Wayne")
                .WithAddress(new AddressBuilder().WithZipCode(90210).WithCity("Beverly Hills").Build())
                .Build();

            Assert.Equal("John", customer.FirstName);
            Assert.Equal(90210, customer.Address.Zipcode);
        }

    }
}