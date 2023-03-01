using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    //Money Transactions
    //On the first line you will receive a collection of bank accounts, consisting of an account number(integer) and its balance(double), in the following format:
    //  "{account number}-{account balance},{account number}-{account balance}, ..."
    //
    //Until the "End" command, you will receive commands which manipulate the given account`s balance:
    //  •	"Deposit {account number} {sum}" – Add the given sum to the given account`s balance.
    //  •	"Withdraw {account number} {sum}" – Subtract the given sum from the account`s balance.
    //
    //Print the following messages from the exceptions which can be produced from your program:
    //  •	If you receive an invalid command: "Invalid command!"
    //  •	If you receive an account which doesn't exist: "Invalid account!"
    //  •	If you receive the "Withdraw" command with a sum which is bigger than the account's balance: "Insufficient balance!"
    //
    //In all cases, after each received command print the message: "Enter another command"
    //After each successful operation print the new balance, formatted to the second integer after the decimal point, in the following format:
    //  •	"Account {account number} has new balance: {balance}"
    //
    //Examples
    //Input
    //  1-45.67,2-3256.09,3-97.34
    //  Deposit 1 50
    //  Withdraw 3 100
    //  End
    //Output
    //  Account 1 has new balance: 95.67
    //  Enter another command
    //  Insufficient balance!
    //  Enter another command
    //
    //Input
    //  1473653-97.34,44643345-2347.90
    //  Withdraw 1473653 150.50
    //  Deposit 44643345 200
    //  Block 1473653 30
    //  Deposit 1 30
    //  End
    //Output
    //  Insufficient balance!
    //  Enter another command
    //  Account 44643345 has new balance: 2547.90
    //  Enter another command
    //  Invalid command!
    //  Enter another command
    //  Invalid account!
    //  Enter another command

    class Program
    {
        static void Main()
        {
            List<BankAccount> accounts = GetAccounts();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                int accountNumber = int.Parse(command[1]);
                double sum = double.Parse(command[2]);

                try
                {
                    switch (command[0])
                    {
                        case "Deposit":
                            Deposit(accounts, accountNumber, sum);
                            break;
                        case "Withdraw":
                            Withdraw(accounts, accountNumber, sum);
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }

                    Console.WriteLine(accounts[accounts
                        .FindIndex(a => a.Number == accountNumber)]
                        .ToString());
                }
                catch (InvalidOperationException invalidCommand)
                {
                    Console.WriteLine(invalidCommand.Message);
                }
                catch (ArgumentException invalidAccount)
                {
                    Console.WriteLine(invalidAccount.Message);
                }
                catch (ArithmeticException invalidSum)
                {
                    Console.WriteLine(invalidSum.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                command = Console.ReadLine().Split();
            }
        }

        private static List<BankAccount> GetAccounts()
        {
            List<BankAccount> accounts = new List<BankAccount>();

            string[] rawAccounts = Console.ReadLine().Split(',');

            for (int i = 0; i < rawAccounts.Length; i++)
            {
                string[] rawAccount = rawAccounts[i].Split('-');
                accounts.Add(new BankAccount(int.Parse(rawAccount[0]), double.Parse(rawAccount[1])));
            }

            return accounts;
        }

        private static int GetAccount(List<BankAccount> accounts, int accountNumber)
        {
            if (accounts.Exists(a => a.Number == accountNumber))
            {
                return accounts.FindIndex(a => a.Number == accountNumber);
            }
            else
            {
                throw new ArgumentException("Invalid account!");
            }
        }

        private static void Deposit(List<BankAccount> accounts, int accountNumber, double sum)
        {
            int accountIndex = GetAccount(accounts, accountNumber);
            accounts[accountIndex].Balance += sum;
        }

        private static void Withdraw(List<BankAccount> accounts, int accountNumber, double sum)
        {
            int accountIndex = GetAccount(accounts, accountNumber);

            if (accounts[accountIndex].Balance < sum)
            {
                throw new ArithmeticException("Insufficient balance!");
            }
            else
            {
                accounts[accountIndex].Balance -= sum;
            }
        }
    }

    class BankAccount
    {
        public BankAccount(int number, double balance)
        {
            Number = number;
            Balance = balance;
        }

        public int Number { get; private set; }
        public double Balance { get; set; }

        public override string ToString()
        {
            return $"Account {Number} has new balance: {Balance:f2}";
        }
    }
}
