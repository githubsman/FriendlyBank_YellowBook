using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    public class PersonalAccount : CustomerAccount, ICustomerAccount
    {
        // YB 4.9  inherited account

        // This class instantiates CustomerAccount with no overrides. 

        //#MARK parameterless constructor prevents cs1729 for inheriting class
        public PersonalAccount(string inName, string inAddress, int inAge, decimal inBalance) : base(inName, inAddress, inAge, inBalance)
        { }

        //  #MARK Constructor, overloaded 
        public PersonalAccount(string inName, string inAddress) : base(inName, inAddress, 42, 1000)
        {     // #MARK 'this' means "another constructor in this class".   YB 4.7.4
              //    In this case, this() has done all that is needed.  So the body is empty.
        }

        public PersonalAccount(int inAge, decimal inBalance) : base("unknown", "unknown", inAge, inBalance)
        { }

        //#MARK parameterless constructor prevents cs1729 for inheriting class
        public PersonalAccount() : base("unknown", "unknown", 42, 1000)
        { }

    }
}
