
namespace FriendlyBank
{
    public class JuniorAccount : CustomerAccount, ICustomerAccount 
    {
        // YB 4.9  inherited account


        public JuniorAccount(string inName, string inAddress, int inAge, decimal inBalance) 
                        : base(inName, inAddress, inAge, inBalance)
        {
            // A constructor cannot throw a failure.  Exceptions are needed to validate data.  YB 4.7.5
            
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
        //
        // public JuniorAccount(string inName, string inAddress) 
        //                 : base(inName, inAddress, 42, 1000)
        // { }
        
        // public JuniorAccount(int inAge, decimal inBalance) 
        //                 : base("unknown", "unknown", inAge, inBalance)
        // { }


        // AccountAllowed is replaced.  In the parent class it is static to allow
        //      testing without instantiation (no account exists); being static, it can't be inherited.

        public static new bool AccountAllowed(decimal transaction_amt, int age) 
        {
            min_age = 9; min_starting_amt = 20;
            return (transaction_amt >= min_starting_amt) && (age >= min_age);
        }
    }
}
