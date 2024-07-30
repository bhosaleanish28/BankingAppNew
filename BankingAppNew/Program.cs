using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager;

namespace BankingAppNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1.accounts = SerialDeserial.DeserializeData();
            Class1.BankingStart();
            SerialDeserial.SerializeData(Class1.accounts);
        }
    }

}
