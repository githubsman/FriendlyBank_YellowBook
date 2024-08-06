
/* TODO:  add precise exceptions
 * https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022
 * */

namespace FriendlyBank
{
    
    public interface ICustomerAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }
    
    public abstract class CustomerAccount : ICustomerAccount
    {
        // #MARK Variables stored in the class may be referred to as *members* or a *properties*. 

        //  See below about static properties. 

        public static int min_age = 18;             // We use CamelCase; 
        public static decimal min_starting_amt = 1000;
        
        internal string account_name;
        internal string account_address;
        internal decimal balance_amt = 0;  // decimal is specifically for financials

        //  For a bank balance_amt, *defensive programming" is required.
        //
        //  Typically,
        //       a property (a.k.a. variable) is private;
        //       a method member (it does something) is public, so it can be called from outside.
        //            Naming convention:  private begins lower-case, public begins upper-case. 
        //            GOOD INTERVIEW QUESTION: Is there a style convention for coding?
        //                                  How is it documented?  What is the state of compliance?  
        //                                  What's the biggest complaint from coders related to this?

        //  A change to the balance_amt can only be made by means of the class method; for example:
        //         > RobsAccount.WithdrawFunds (5)              ... #MARK Security is achieved through encapsulation.  

        // TODO Replace if() with  try-catch{}
        // TODO Replace 'return false' with exceptions, ex OutOfRange


        //  #MARK Constructor (YB 4.7) 
        
        public CustomerAccount(string inName, string inAddress, int inAge, decimal inBalance)        
        {
            account_name = inName;
            account_address = inAddress;
            balance_amt = inBalance;
        }

        public bool WithdrawFunds(decimal transaction_amt)
        {
            if (balance_amt < transaction_amt)
            {
                return false;
            }
            balance_amt -= transaction_amt;
            return true;
        }

        public void PayInFunds(decimal transaction_amt)
        {
            balance_amt += transaction_amt;
        }

        public decimal GetBalance()
        {
            return balance_amt;
        }

        //      public static decimal interest_rate;  (above)

        //  #MARK a *static* property is a member of the class, BUT it is not a
        //          a member of an instance of the class.   Yellow Book 4.6.1. 
        //      The effect for interest_rate is to 
        //          (1) declare a global constant (YB 4.6.3), and
        //          (2) make it globally available regardless of whether the class has been instantiated.  
        //      "Static" does NOT mean immutability (although stability is implied in (1) above).  
        //  Below is a static method that lets us check eligibility for a *potential* bank customer.
        //    In other words, it can execute without an instance.  
        //    (This makes obvious sense for the Main() method:  You need to be able 
        //     to start the program without first instantiating a class.
        //     It's also indispensible for libraries where a function should "just work".)
        //  A static method can only consume static class members.  YB 4.6.3.
        //     private readonly decimal interest_rate   could serve as a class member. 

        public static bool AccountAllowed(decimal transaction_amt, int age)
        {
            return (transaction_amt >= min_starting_amt) && (age >= min_age);
        }

    }
}