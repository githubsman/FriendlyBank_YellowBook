using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// THIS IS PROLLY A TEMPORARY BIT OF CODE.   Yellow Book 4.5.2. 
//  The file BankProgram.cs is currently commented out; it should be reinstated to handle the Main() method.

namespace FriendlyBank
{
    class Bank
    {
        public static void Main ()
        {

            Account RobsAccount;
            RobsAccount = new Account("Rob", "123 Gingham St", 100000);


            if ( RobsAccount.WithdrawFunds (5) ) 
            {
                Console.WriteLine ("cash withdrawn");
            } 
            else
            {
                Console.WriteLine("insufficient funds");
            }
        }

    }

}
