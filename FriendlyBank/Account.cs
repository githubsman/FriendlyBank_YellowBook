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
    public class Account
    {
        // #MARK This is a variable stored in the class;
        //  known in this context as a *member* or a *property*. 

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

        private decimal balance_amt = 0;  // the decimal type is specifically designed for financial values
        public static decimal interest_rate;
        public static decimal min_starting_amt = 1000;
        public static decimal min_age = 18;

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
        //          (1) declare a global constant, and
        //          (2) make it globally available regardless of whether the class has been instantiated.  
        //      "Static" does NOT mean immutability (although stability is implied in (1) above).  
        //  Below is a static method that lets us check eligibility for a *potential* bank customer - no account instantiated! 
        //    (This makes obvious sense for the Main() method:  You need to be able 
        //     to start the program without first instantiating a class.)         

        public static bool AccountAllowed(decimal starting_amt, int age)
        {
            return (starting_amt >= min_starting_amt) && (age >= min_age);
        }

    }
}