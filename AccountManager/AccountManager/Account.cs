using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountBankName { get; set; }
        public double AccountBalance { get; set; }
        public string AadharNumber { get; set; }

        public const double MIN_BALANCE = 500;

        public Account()
        {
        }
        public Account(int accountNumber, string accountName, string accountBankName)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            AccountBankName = accountBankName;
            AccountBalance = MIN_BALANCE;
        }

        public Account(int accountNumber, string accountName, string accountBankName, double accountBalance) : this(accountNumber, accountName, accountBankName)
        {
            AccountBalance = accountBalance;
        }

        public Account(int accountNumber, string accountName, string accountBankName, string aadharNumber) : this(accountNumber, accountName, accountBankName)
        {
            AadharNumber = aadharNumber;
        }

        public Account(int accountNumber, string accountName, string accountBankName, string aadharNumber, double accountBalance) : this(accountNumber, accountName, accountBankName, accountBalance)
        {
            AadharNumber = aadharNumber;
        }


        public void PrintDetails()
        {
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Account Name: " + AccountName);
            Console.WriteLine("Account Bank Name: " + AccountBankName);
            Console.WriteLine("Account Balance: " + AccountBalance);
            Console.WriteLine("Account Aadhar Number: " + AadharNumber);
            Console.WriteLine();
        }

        public void Deposit()
        {
            Console.WriteLine("Enter the deposit amount: ");
            double depositAmount = double.Parse(Console.ReadLine());
            AccountBalance += depositAmount;
            Console.WriteLine("Amount added succesfully");
            SerialDeserial.SerializeData(Class1.accounts);
        }

        public void Withdraw()
        {
            Console.WriteLine("Enter amount to withdraw: ");
            double withdrawAmount = double.Parse(Console.ReadLine());

            if (withdrawAmount > AccountBalance)
            {
                Console.WriteLine("Insufficient Balance.");
            }
            else if (AccountBalance - withdrawAmount < MIN_BALANCE)
            {
                Console.WriteLine("Minimum Balance 500 required.");
            }
            else
            {
                AccountBalance -= withdrawAmount;
                Console.WriteLine("New Balance:" + AccountBalance);
                SerialDeserial.SerializeData(Class1.accounts);
            }

        }
    }
}
