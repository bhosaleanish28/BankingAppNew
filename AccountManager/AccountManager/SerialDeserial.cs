using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AccountManager
{
    public class SerialDeserial
    {
        public static void SerializeData(List<Account> accounts)
        {
            string json = JsonConvert.SerializeObject(accounts);
            File.WriteAllText("NewAccountData.json", json);
        }

        public static List<Account> DeserializeData()
        {
            List<Account> accounts = new List<Account>();
            string filename = "NewAccountData.json";
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                accounts = JsonConvert.DeserializeObject<List<Account>>(json);
            }
            return accounts;
        }
    }
}
