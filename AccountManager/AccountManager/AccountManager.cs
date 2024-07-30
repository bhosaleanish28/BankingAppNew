using System.Security.Principal;

namespace AccountManager
{
    public class Class1
    {
        public static List<Account> accounts = new List<Account>();

        public static void BankingStart()
        {

            bool isMenuRunning = true;

            while (isMenuRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Banking App");
                Console.WriteLine("Select Login: ");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit Banking App");

                int loginChoice = int.Parse(Console.ReadLine());

                switch (loginChoice)
                {
                    case 1:
                        AdminBanking();
                        break;
                    case 2:
                        UserBanking();
                        break;
                    case 3:
                        isMenuRunning = false;
                        break;
                }

            }
        }

        public static void AdminBanking()
        {
            bool adminRunning = true;
            while (adminRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Admin Panel");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine("1. Add New Account.");
                Console.WriteLine("2. Display All Account.");
                Console.WriteLine("3. Find Account by ID.");
                Console.WriteLine("4. Update an account.");
                Console.WriteLine("5. Remove an account.");
                Console.WriteLine("6. Clear all accounts.");
                Console.WriteLine("7. Exit from Admin Panel.");

                int adminChoice = int.Parse(Console.ReadLine());

                switch (adminChoice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DisplayAllDetails();
                        break;
                    case 3:
                        GetAccountByID();
                        break;
                    case 4:
                        UpdateDetails();
                        break;
                    case 5:
                        RemoveAccount();
                        break;
                    case 6:
                        ClearAllAccounts();
                        break;
                    case 7:
                        adminRunning = false;
                        break;

                }
            }

        }

        public static void AddAccount()
        {
            Console.WriteLine("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter account name: ");
            string accountName = Console.ReadLine();

            Console.WriteLine("Enter Bank Name: ");
            string accountBankName = Console.ReadLine();

            Console.WriteLine("Enter Bank Balance: ");
            double accountBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Aadhar Number: ");
            string aadharNumber = Console.ReadLine();
            Account account = new Account(accountNumber, accountName, accountBankName, aadharNumber, accountBalance);
            accounts.Add(account);

            Console.WriteLine("Account added successfully!");
            Console.WriteLine();


            SerialDeserial.SerializeData(accounts);
        }

        public static void DisplayAllDetails()
        {
            Console.WriteLine("All Accounts:");

            foreach (var account in accounts)
            {
                if (account is Account acc)
                {
                    acc.PrintDetails();
                }
                Console.WriteLine();
            }
        }

        public static void GetAccountByID()
        {
            Console.WriteLine("Enter Account Number: ");
            int userInputNumber = int.Parse(Console.ReadLine());

            bool foundAccount = false;
            foreach (var account in accounts)
            {
                if (account is Account acc && userInputNumber == acc.AccountNumber)
                {
                    acc.PrintDetails();
                    foundAccount = true;
                    break;
                }

            }
            try 
            {
                if (!foundAccount)
                {
                    throw new NoAccount("No Account Found");
                }
            }
            catch (NoAccount account)
            {
                Console.WriteLine(account.Message);
            }

        }

        public static void UpdateDetails()
        {
            Console.WriteLine("Enter account number: ");
            int userInput = int.Parse(Console.ReadLine());

            Account foundAccount = null;

            foreach (var account in accounts)
            {
                if (account is Account acc && userInput == acc.AccountNumber)
                {

                    foundAccount = acc;
                    break;
                }
            }

            if (foundAccount != null)
            {

                Console.WriteLine("Enter new account number: ");
                foundAccount.AccountNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new account name: ");
                foundAccount.AccountName = Console.ReadLine();

                Console.WriteLine("Enter new bank name: ");
                foundAccount.AccountBankName = Console.ReadLine();

                Console.WriteLine("Enter new account balance: ");
                foundAccount.AccountBalance = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter new Aadhar Number: ");
                foundAccount.AadharNumber = Console.ReadLine();

                Console.WriteLine("Account Updated Successfully!");
                Console.WriteLine();

                foundAccount.PrintDetails();


                SerialDeserial.SerializeData(accounts);
            }

        }

        public static void RemoveAccount()
        {
            Console.WriteLine("Enter account number: ");
            int userInput = int.Parse(Console.ReadLine());

            Account foundAccount = null;
            foreach (var account in accounts)
            {
                if (account is Account acc && userInput == acc.AccountNumber)
                {
                    foundAccount = acc;
                    break;
                }
            }
            if (foundAccount != null)
            {
                accounts.Remove(foundAccount);
                Console.WriteLine("Account removed successfully");


                SerialDeserial.SerializeData(accounts);
            }
            else
            {
                Console.WriteLine("No account found");
            }
            Console.WriteLine();
        }

        public static void ClearAllAccounts()
        {
            accounts.Clear();
            Console.WriteLine("All accounts deleted successfully");


            SerialDeserial.SerializeData(accounts);
        }

        public static void UserBanking()
        {
            bool userRunning = true;

            while (userRunning)
            {
                Console.WriteLine("Welcome to User Panel");
                Console.WriteLine("Enter your account number: ");
                int userInput = int.Parse(Console.ReadLine());

                Account selectedAccount = null;
                foreach (var account in accounts)
                {
                    if (account is Account acc && userInput == acc.AccountNumber)
                    {
                        selectedAccount = acc;
                        break;
                    }
                }
                Console.WriteLine($"Selected Account: {selectedAccount.AccountName}-{selectedAccount.AccountBankName}");
                Console.WriteLine();

                Console.WriteLine("Account Operations: ");
                Console.WriteLine("1. Check Account Details.");
                Console.WriteLine("2. Deposit Money.");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Select a different Account");
                Console.WriteLine("5. Exit from user.");
                Console.WriteLine("Enter your choice: ");
                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        selectedAccount.PrintDetails();
                        break;

                    case 2:
                        selectedAccount.Deposit();
                        break;

                    case 3:
                        selectedAccount.Withdraw();
                        break;

                    case 4:
                        Console.WriteLine("Enter your account number: ");
                        int newUserInput = int.Parse(Console.ReadLine());
                        Account newAccount = null;
                        foreach (var account in accounts)
                        {
                            if (account is Account acc && newUserInput == acc.AccountNumber)
                            {
                                newAccount = acc;
                                break;
                            }
                        }
                        selectedAccount = newAccount;
                        Console.WriteLine($"Selected Account: {selectedAccount.AccountName}-{selectedAccount.AccountBankName}");
                        break;

                    case 5:
                        userRunning = false;
                        break;
                }


            }


        }

    }
}
