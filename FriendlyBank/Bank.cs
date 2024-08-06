
// THIS IS PROLLY A TEMPORARY BIT OF CODE.   Yellow Book 4.5.2. 
//  The file BankProgram.cs is currently commented out; it should be reinstated to handle the Main() method.

namespace FriendlyBank
{
    class Bank
    {
        public static void Main ()
        {

            // USING CONSTRUCTORS
            //RobsAccount = new CustomerAccount("Rob", "123 Gingham St", 42, 100000);

            ICustomerAccount RobsAccount = new PersonalAccount("Rob", "123 Gingham St", 42, 100000);
            
            RobsAccount.PayInFunds(50);
            Console.WriteLine("Balance: " + RobsAccount.GetBalance());

            // IDE0090 recommended.  Ignore this recommendation. 
            ICustomerAccount BillysAccount = new JuniorAccount("Billy", "123 Gingham St", 11, 30);

            BillysAccount.PayInFunds(50);
            Console.WriteLine("Balance: " + BillysAccount.GetBalance());

        }

    }

}

