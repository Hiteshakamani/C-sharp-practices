using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{

    //Account class
    public class Account
    {
        public string Name { get; set; }
        public int Account_number { get; set; }
        public decimal Balance { get; set; }
        public List<string> Transaction_history {get; set;}

        public Account(string name ,int account_number, decimal balance)
        {
            Name = name;
            Account_number = account_number;
            Balance = balance;
            Transaction_history = new List<string>();
            
        }
    }

    // Bank Class
    public class Bank
    {
        private List<Account> accounts;
        public string Name { get; set; }

        public Bank(List<Account> accounts, string name)
        {
            this.accounts = accounts;
            Name = name;  
        }
        // For creating an account
        public void create_account(string name , decimal balnce)
        {
            int account_number = accounts.Count + 1;
            Account account = new Account(name, account_number, balnce);   
            accounts.Add(account);
        }
         // For deposite

        public void deposite(int account_number,decimal money )
        {
            Account account = accounts.Find(a=>a.Account_number == account_number);
            if(account != null)
            {
                account.Balance += money;
                account.Transaction_history.Add($"Deposited {money} on {DateTime.Now}")
            }
        }

        //  For Withdraw
         public bool withdraw(int account_number , decimal money)
        {
            Account account = accounts.Find(a=> a.Account_number==account_number);
            if (account != null)
            {
                if(account.Balance > money) 
                {
                    account.Balance -= money;
                    account.Transaction_history.Add($"Withdrawn {money} on {DateTime.Now}");
                    return true;
                }
            }
            return false;
        }

        // For check balance
        public decimal Check_balance(int account_number)
        {
            Account account = accounts.Find(a=>a.Account_number==account_number) ;
            if (account != null)
            {
                return account.Balance;
            }
            return -1 ;
        }

        public List<string> Transaction_history(int account_number)
        {
            Account account = accounts.Find(a=>a.Account_number == account_number);
            if(account != null )
            {
                return account.Transaction_history;
            }
            return null;
        }

    }

    // Main class
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            Bank bank = new Bank(accounts,"SBI bank");
            Console.WriteLine("Welcome to " + bank.Name);

            while(true)
            {
                Console.WriteLine("Select an Option : ");
                Console.WriteLine("1. Create account");
                Console.WriteLine("2. Deposit money ");
                Console.WriteLine("3. Withdraw money ");
                Console.WriteLine("4. Check balance ");
                Console.WriteLine("5. View transaction history ");
                Console.WriteLine("6. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter name");
                            string name=Console.ReadLine();
                            Console.WriteLine("Enter balance: ");
                            decimal balance;
                            if (decimal.TryParse(Console.ReadLine(), out balance))
                            {
                                bank.create_account(name, balance);
                                Console.WriteLine("Account Created Successfully...!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            break;

                         case 2:
                            Console.WriteLine("Enter account number : ");
                            int account_number;
                            if (int.TryParse(Console.ReadLine(), out account_number))
                            {
                                Console.WriteLine("Enter amount to deposite :");
                                decimal money;
                                if (decimal.TryParse(Console.ReadLine(), out money))
                                {
                                    bank.deposite(account_number, money);
                                    Console.WriteLine("DEposite successfull...!");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid money....😒");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid money....😒");
                            }
                    break;
                            case 3 :
                            Console.WriteLine("Enter account number : ");
                           
                            if (int.TryParse(Console.ReadLine(), out account_number))
                            {
                                Console.WriteLine("Enter amount to withdrw :");
                                decimal money;
                                if (decimal.TryParse(Console.ReadLine(), out money))
                                {
                                    if(bank.withdraw(account_number, money))
                                    {
                                        Console.WriteLine("Withdraw successfull...!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient balance....😒");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid money....😒");
                            }


                            break;


                        case 4:
                            Console.WriteLine("Enter account number : ");
                            if (int.TryParse(Console.ReadLine(), out account_number))
                            {
                                decimal account_balance = bank.Check_balance(account_number);
                                if (account_balance != -1)
                                {
                                    Console.WriteLine($"Account balance : {account_balance}");
                                }
                                else
                                {
                                    Console.WriteLine("Account not found.");
                                }
                            }
                    
                            else
                             {
                                 Console.WriteLine("Invalid input.");
                             }
                    break;
                            case 5:
                            Console.WriteLine("Enter account number : ");
                            if (int.TryParse(Console.ReadLine(),out account_number))
                            {
                                List<string> transaction_History = bank.Transaction_history(account_number);
                                if(transaction_History != null)
                                {
                                    Console.WriteLine($"Transaction history of account number {account_number} :");
                                    foreach (string transaction in transaction_History)
                                    {
                                        Console.WriteLine(transaction);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Account not found...!")
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            
                            break;
                        case 6:
                            Console.WriteLine("Thanks....😊");
                            
                            break;
                        default:
                            Console.WriteLine("No option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}
