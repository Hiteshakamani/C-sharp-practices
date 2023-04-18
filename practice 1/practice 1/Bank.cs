using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_1
{
     //Exercise: Creating a Bank Account Class with Multiple Namespaces
        // This execrise mainly cover the topics like namespace , classes , constructor , condiotional statements etc 
    
        public class BankAccount
        {
            private string accountNumber;
            private string accountHolder;
            private decimal balance;

            public BankAccount(string accountNumber, string accountHolder, decimal balance)
            {
                this.accountNumber = accountNumber;
                this.accountHolder = accountHolder;
                this.balance = balance;
            }

            public string AccountNumber
            {
                get { return accountNumber; }
                set { accountNumber = value; }
            }

            public string AccountHolder
            {
                get { return accountHolder; }
                set { accountHolder = value; }
            }

            public decimal Balance
            {
                get { return balance; }
                set { balance = value; }
            }

            public void Deposit(decimal amount)
            {
                balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (amount > balance)
                {
                    throw new Exception("You have insufficient balance");
                }
                balance -= amount;
            }
        }
    }



