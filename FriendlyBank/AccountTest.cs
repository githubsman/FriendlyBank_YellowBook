using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    class AccountTest
    {
        public static void Test_PayInFunds_good()
        {
            Account test = new Account();
            test.PayInFunds(50);
            Console.WriteLine("Balance: " + test.GetBalance());
        }
        public static void Test_AccountAllowed_good()
        {
            decimal test_amt = 5000;
            int test_age = 20;

            Console.WriteLine("The result should be true: " + Account.AccountAllowed(test_amt, test_age));
        }
    }
}
