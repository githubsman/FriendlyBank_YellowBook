using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    public class JuniorAccount : CustomerAccount, ICustomerAccount
    {
        // YB 4.9  inherited account

        static new int min_age = 9;
        static new decimal min_starting_amt = 20;

        // This class instantiates CustomerAccount. 
        // AccountAllowed is replaced.  In the parent class it is static (this is to allow
        // testing for a proposed instance); being static, it can't be inherited. 

        //#MARK parameterless constructor prevents cs1729 for inheriting class
        public JuniorAccount(string inName, string inAddress, int inAge, decimal inBalance) : base(inName, inAddress, inAge, inBalance)
        { }

        //  #MARK Constructor, overloaded 
        public JuniorAccount(string inName, string inAddress) : base(inName, inAddress, 42, 1000)
        { }

        public JuniorAccount(int inAge, decimal inBalance) : base("unknown", "unknown", inAge, inBalance)
        { }

        // //#MARK parameterless constructor prevents cs1729 for inheriting class
        // public JuniorAccount() : base("unknown", "unknown", 42, 1000)
        // { }


        public static new bool AccountAllowed(decimal transaction_amt, int age) 
        {
            return (transaction_amt >= min_starting_amt) && (age >= min_age);
        }
    }
}
