using System;

// #MARK enumerated type    (yellow book, 79ff)
//   A user-defined data type; useful for *states*.  It's generally helpful for an object to have state.  
//   Functionally (similar to) a drop-down menu populated from a value list that cannot be altered. 
//  

enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
}


// #MARK structure    (p 82-85)
//  A member-specific set of C# variables that will be treated as an entity which has fields.
//  Arrays of structures are highly useful.  Each array member is an instance of the structure.  

//  Substitute 'class' for 'struct' below, and you have created a class.  
//   BUT structures deal in *values*, in contrast to objects which deal in *references*. 
//  This provides a springboard to discuss objects on p88-90. 

//      Account MyNamedAccount;              <<   To use a structure      
                                                                                          
//      Account MyNamedAccount;              <<   To use a class ...    
//      MyNamedAccount = new Account();              ... you create an instance 

//  (Functionally, a structure is a table -- which is nice if you don't have a database at hand). 

//  p.89:
//  An object is an instance of a class.
//  An object is created using the keyword 'new'.   (NB: An array is implemented as an object.)  

struct Account
{
    public AccountState State;
    public string Name;
    public string Address;
    public int AccountNumber;
    public int Balance;
    public int Overdraft; 
};

//       ^  ^  ^  ^  ^        ^  ^  ^  
//  The enumerated type and structure are declared outside the class.  
//  

class BankProgram
{

    public static void Main()
    {

        const int MAX_CUST = 100;
        Account[] Bank = new Account[MAX_CUST];

        // code sample 24, 25

        Bank[0].Name = "Rob";
        Bank[0].State = AccountState.Active;
        Bank[0].Balance = 1000000;

        Bank[1].Name = "Jim";
        Bank[1].State = AccountState.Frozen;
        Bank[1].Balance = 0;

        PrintAccount(Bank[0]);
        PrintAccount(Bank[1]);
    }

    private static void PrintAccount(Account a)
    {
        Console.WriteLine("Name: " + a.Name);
        Console.WriteLine("Address: " + a.Address);
        Console.WriteLine("Balance: " + a.Balance);
    }
}


