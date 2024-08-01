
// #MARK interface    YB 4.8.3
//  The class contains the concrete versions of the methods.  
//  All its methods must be represented here.  

    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }

   
    public class CustomerAccount : IAccount
    {

        public static decimal interest_rate;
        public static decimal min_starting_amt = 1000;
        public static decimal min_age = 18;

        private string account_name;
        private string account_address;
        private decimal balance_amt = 0;  

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

        public static bool AccountAllowed(decimal transaction_amt, int age)
        {
            return (transaction_amt >= min_starting_amt) && (age >= min_age);
        }

    }


class Bank
{
    public static void Main()
    {
        IAccount account = new CustomerAccount();
        account.PayInFunds(50);
        Console.WriteLine("Balance: " + account.GetBalance());
    }
}
