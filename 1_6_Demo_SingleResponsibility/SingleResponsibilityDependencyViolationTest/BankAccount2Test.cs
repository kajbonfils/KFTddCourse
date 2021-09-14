using System;
using SingleResponsibilityViolation;
using SingleResponsibilityViolation.Repository;
using SingleResponsibilityViolation.Service;
using Xunit;

namespace SingleResponsibilityDependencyViolationTest
{
    public class BankAccount2Test
    {
        [Fact]

        public void WithdrawMoney_CallsGetBalanceWithCorrectArgument()
        {
            var bankRepository = new BankRepositoryStub();
            bankRepository.GetBalanceResult = 10001;
            var target = new BankAccount2(bankRepository);
            target.Cprnummer = "1234567890";
            target.WithdrawMoney(10000);

            Assert.Same("1234567890", bankRepository.GetBalanceSsnArgument);
        }

        [Fact]
        public void WithdrawMoney_BalanceAfterWithdrawalNegative_ThrowsException()
        {
            var bankRepository = new BankRepositoryStub();
            bankRepository.GetBalanceResult = 10000;

            var target = new BankAccount2(bankRepository);

            Assert.Throws<ArgumentException>(() => target.WithdrawMoney(20000));
        }

        [Fact]
        public void WithdrawMoney_BalanceIsPositive_CallsWithdrawRequest()
        {
            var bankRepository = new BankRepositoryStub();
            bankRepository.GetBalanceResult = 10000;

            var target = new BankAccount2(bankRepository)
            {
                Cprnummer = "12312312324"
            };
            target.WithdrawMoney(5000);

            Assert.Equal("12312312324", bankRepository.WithDrawSssnArgument);
            Assert.Equal(5000, bankRepository.WithDrawAmountArgument);
        }

        [Fact]
        public void WithdrawMoney_BalanceIsPositive_ReturnsNewBalance()
        {
            var bankRepository = new BankRepositoryStub();
            bankRepository.GetBalanceResult = 10000;

            var target = new BankAccount2(bankRepository);

            var actual = target.WithdrawMoney(2000);

            Assert.Equal(8000, actual);
        }

    }
}