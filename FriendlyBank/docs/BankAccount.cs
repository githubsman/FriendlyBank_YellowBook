/*
 *  https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022
 *  See companion project "BankAccountTests"
 * 
 *  Don't get confused with https://learn.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2022
 *      This alternate tutorial (also from 2024-11) uses a "Bank solution" with different code. 
 *      It may have valuable insights generally.  
 */


namespace ...

    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        public const string Outcome_AmountExceedsBalance = "Debit amount exceeds balance";
        public const string Outcome_AmountLessThanZero = "Debit amount is less than zero";


        ///private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void WithdrawFunds(double transaction_amt)
        {
            if (transaction_amt > m_balance)
            {
                throw new ArgumentOutOfRangeException("transaction_amt", transaction_amt, Outcome_AmountExceedsBalance);
            }

            if (transaction_amt < 0)
            {
                throw new ArgumentOutOfRangeException("transaction_amt", transaction_amt, Outcome_AmountLessThanZero);
            }

            //m_balance += transaction_amt; // intentionally incorrect code 
            //m_balance -= transaction_amt + 0.0001; // this manages to pass; could modify the assert statement
            //m_balance -= transaction_amt + 0.001; // intentionally incorrect code 
            m_balance -= transaction_amt;
        }

        public void PayInFunds(double transaction_amt)
        {
            if (transaction_amt < 0)
            {
                throw new ArgumentOutOfRangeException("transaction_amt");
            }

            m_balance += transaction_amt;
        }


        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.PayInFunds(5.77);
            ba.WithdrawFunds(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}