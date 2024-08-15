
namespace FriendlyBank
{
    public class JuniorAccount : CustomerAccount, ICustomerAccount 
    {
        // YB 4.9  inherited account
        public new static int min_age = 10;
        public static int max_age = 17;
        public new static decimal min_starting_amt = 100;

        public JuniorAccount(string inName, string inAddress, int inAge, decimal inBalance) 
                        : base(inName, inAddress, inAge, inBalance)
        {
            //MARK A constructor cannot throw a failure.  Exceptions are needed to validate data.  YB 4.7.5
            
            string errorMessage = "";
            
            if (   AccountAllowed(inBalance, inAge)==false)
            {
                errorMessage = errorMessage + "Minimal eligibility not met: " + inAge + ", " + inBalance;
            }
            
            if (errorMessage != "")
            {
                throw new Exception("CustomerAccount construction failed: " + errorMessage);
            }

        }
        
        public JuniorAccount(int inAge, decimal inBalance) : base("unknown", "unknown", inAge, inBalance)
        // this constructor very usefully lets you check a potential account-holder for eligibility 
        //  without the need to submit a name or address. 
        { }


        // AccountAllowed is replaced.  In the abstract class it is static to allow
        //      testing without instantiation (no account exists); being static, it can't be inherited.
        //  In this class, replacing the method makes class-specific properties are available -- also max_age criterion. 
        public static new bool AccountAllowed(decimal transaction_amt, int age) 
        {
            return (transaction_amt >= min_starting_amt) && (age >= min_age) && (age <= max_age);
        }
    }
}
