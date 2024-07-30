using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    public class NoAccount:Exception
    {
        public NoAccount(string msg) : base(msg) 
        { }
    }
}
