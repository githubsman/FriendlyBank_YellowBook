using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

// THIS IS PROLLY A TEMPORARY BIT OF CODE.   Yellow Book 4.5.2. 
//  The file BankProgram.cs is currently commented out; it should be reinstated to handle the Main() method.

namespace FriendlyBank
{
    class Bank
    {
        public static void Main ()
        {

            //ICustomerAccount RobsAccount = new CustomerAccount();
            //  CS0266  Cannot implicitly convert type 'FriendlyBank.CustomerAccount' to 'FriendlyBank.ICustomerAccount'.

            ICustomerAccount RobsAccount = new CustomerAccount("Rob", "123 Gingham St", 42, 100000);


            RobsAccount.PayInFunds(50);
            Console.WriteLine("Balance: " + RobsAccount.GetBalance());



            // USING CONSTRUCTORS
            //RobsAccount = new CustomerAccount("Rob", "123 Gingham St", 42, 100000);

        }

    }

}

