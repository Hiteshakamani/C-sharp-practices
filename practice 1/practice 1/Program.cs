using practice_1;
using System;

namespace Bank_Front
{
    class Front
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("10", "Hitesha", 500);
            account.Deposit(570);
            account.Withdraw(50);
            Console.WriteLine($"Account number : {account.AccountNumber}");
            Console.WriteLine($"Account holder : {account.AccountHolder}");
            Console.WriteLine($"Balance : {account.Balance:C}");
        }
    }
}