using System;
using SingleResponsibilityViolation;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("101085-1055", "Anders", "And", new Address("Paradisæblevej", 111, 1313, "Andeby"));

            var bankKonto = new BankAccount();
            bankKonto.Customer = customer;

            try
            {
                var saldo = bankKonto.WithdrawMoney(1000);
                Console.WriteLine("Du har hævet 50000 kr og saldoen er nu " + saldo);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Du har overtrukket din konto");
            }
        }
    }
}
