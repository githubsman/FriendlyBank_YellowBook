
namespace FriendlyBank
{

    public class PersonalAccount : CustomerAccount, ICustomerAccount
    {
        // YB 4.9  inherited account

        // This class instantiates the abstract class CustomerAccount with no overrides. 
        public new static int min_age = 18;
        public new static decimal min_starting_amt = 1000;


        public PersonalAccount(string inName, string inAddress, int inAge, decimal inBalance) 
                                : base(inName, inAddress, inAge, inBalance)
        {
            string errorMessage = "";

            if (AccountAllowed(inBalance, inAge) == false)
            {
                errorMessage = errorMessage + "Minimal eligibility not met: " + inAge + ", " + inBalance;
            }

            if (errorMessage != "")
            {
                throw new Exception("CustomerAccount construction failed: " + errorMessage);
            }
        }

        public PersonalAccount(string inName, string inAddress) : base(inName, inAddress, 42, 1000)
                // MARK 'this' means "another constructor in this class".   YB 4.7.4
        { }     //    In this case, the body { } is empty because this() has done all that is needed.  

        public PersonalAccount(int inAge, decimal inBalance) : base("unknown", "unknown", inAge, inBalance)
        // MARK Constructor, overloaded.  It very usefully lets you check a potential account-holder
        //   for eligibility without submitting a name or address. 
        { }

        public static new bool AccountAllowed(decimal transaction_amt, int age)
        {
            return (transaction_amt >= min_starting_amt) && (age >= min_age);
        }

    }
}
