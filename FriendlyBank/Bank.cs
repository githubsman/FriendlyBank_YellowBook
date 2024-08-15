
// THIS IS PROLLY A TEMPORARY BIT OF CODE.   Yellow Book 4.5.2. 
//  The file BankProgram.cs is currently commented out; it should be reinstated to handle the Main() method.

using System.Security.Principal;

namespace FriendlyBank
{

    // #MARK enumerated type       Yellow Book 4.2
    //   A user-defined data type; useful for *states*.  It's generally helpful for an object to have state.  
    //   Functionally (similar to) a drop-down menu populated from a value list that cannot be altered. 
    //   The declaration is outside the class.  

    enum AccountState
    {
        New,
        Active,
        UnderAudit,
        Frozen,
        Closed
    }

    class Bank
    {
        public static void Main()
        {
            // MARK Encapsulation: our interface should prevent us from using the class directly...
            // PersonalAccount RobsAccount = new PersonalAccount("Rob", "123 Gingham St", 42, 100000);  <<<  this should not be allowed.  FIXME ?
            
            ICustomerAccount RobsAccount = new PersonalAccount("Rob", "123 Gingham St", 42, 100000);
            RobsAccount.PayInFunds(50);
            PrintAccount((CustomerAccount)RobsAccount);

            ICustomerAccount BillysAccount = new JuniorAccount("Billy", "123 Gingham St", 11, 130);
            BillysAccount.PayInFunds(50);
            PrintAccount((CustomerAccount)BillysAccount);
        }

        private static void PrintAccount(CustomerAccount a)
        {
            string ReportOutput;
            ReportOutput = "Name: " + a.account_name;
            ReportOutput += "\r\n  Address: " + a.PhysAddress();
            ReportOutput += "\r\n  Acct Type: " + a.GetAccountState();
            ReportOutput += "\r\n  Balance: " + a.GetBalance();

            Console.WriteLine(ReportOutput);

        }
    }

}

