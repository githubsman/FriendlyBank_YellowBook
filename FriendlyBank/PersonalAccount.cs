﻿
namespace FriendlyBank
{

    public class PersonalAccount : CustomerAccount, ICustomerAccount
    {
        // YB 4.9  inherited account

        // This class instantiates the abstract class CustomerAccount with no overrides. 



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

        //  #MARK Constructor, overloaded 
        public PersonalAccount(string inName, string inAddress) 
                        : base(inName, inAddress, 42, 1000)
                // #MARK 'this' means "another constructor in this class".   YB 4.7.4
                //    In this case, this() has done all that is needed.  So the body is empty.
        { }
        
        //public PersonalAccount(int inAge, decimal inBalance) 
        //                : base("unknown", "unknown", inAge, inBalance)
        //{ }

    }
}
