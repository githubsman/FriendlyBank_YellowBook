using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
    
    public class StandardPersonalAcct : ICustomerAccount
    {
        // #MARK Variables stored in the class may be referred to as *members* or a *properties*. 

        //  See below about static properties. 
        public static decimal interest_rate;
        public static decimal min_starting_amt = 1000;
        public static decimal min_age = 18;

        private string account_name;
        private string account_address;
        private decimal balance_amt = 0;  // the decimal type is specifically designed for financial values


        //  For a bank balance_amt, *defensive programming" is required.
        //
        //  Typically,
        //       a property (a.k.a. variable) is private;
        //       a method member (it does something) is public, so it can be called from outside.
        //            Naming convention:  private begins lower-case, public begins upper-case. 
        //            GOOD INTERVIEW QUESTION: Is your style convention for coding documented?  How good is compliance?  

        //  A change to the balance_amt can only be made by means of the class method; for example:
        //         > RobsAccount.WithdrawFunds (5)              ... #MARK Security is achieved through encapsulation.  

        // TODO Replace if() with  try-catch{}
        // TODO Replace 'return false' with exceptions, ex OutOfRange


        //  #MARK Constructor (YB 4.7) 
        
        public StandardPersonalAcct(string inName, string inAddress, int inAge, decimal inBalance)        
        {
            // A constructor cannot throw a failure.  Data validation using exceptions is necessary.  YB 4.7.5
        
            string errorMessage = "";
        
            if (AccountAllowed(inBalance, inAge)==false)
            {
                errorMessage = errorMessage + "Minimal eligibility not met: " + inAge + ", " + inBalance;
            }
        
            if (errorMessage != "")
            {
                throw new Exception("StandardPersonalAcct construction failed: " + errorMessage);
            }
        
            account_name = inName;
            account_address = inAddress;
            balance_amt = inBalance;
        }
        
        public StandardPersonalAcct(string inName, string inAddress) :                         //  #MARK Constructor, overloaded 
            this(inName, inAddress, 42, 1000)
        {     // #MARK 'this' means "another constructor in this class".   YB 4.7.4
              //    In this case, this() has done all that is needed.  So the body is empty.
        }
        
        public StandardPersonalAcct(int inAge, decimal inBalance) :                        
            this("unknown", "unknown", inAge, inBalance)
        { }   

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
        //  A static method can only consume static class members (again: interest_rate). YB 4.6.3.

        public static bool AccountAllowed(decimal transaction_amt, int age)
        {
            return (transaction_amt >= min_starting_amt) && (age >= min_age);
        }

    }
}