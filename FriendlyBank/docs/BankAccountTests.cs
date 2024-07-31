
namespace ...
{
    [TestClass]
    public class BankAccountTests
    {

        //  A test method must:
        //      - be decorated with the attribute [TestMethod]
        //      - not have parameters
        //      - return void
        //  In a test unit project, not all classes need be [TestClass] and 
        //  not all methods need by [TestMethod].

      

        [TestMethod]
        public void WithdrawFunds_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double transaction_amt = 4.55;
            double expectedBalance = 7.44;
            BankAccount account = new BankAccount("Ms Unite Testy", beginningBalance);

            // Act
            account.WithdrawFunds(transaction_amt);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expectedBalance, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void WithdrawFunds_AmountLessThanZero_ExceptionType()
        {
            // Arrange
            double beginningBalance = 11.99;
            double transaction_amt = -2.00;
            BankAccount account = new BankAccount("Ms Unite Testy", beginningBalance);

            // Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.WithdrawFunds(transaction_amt));
        }

        [TestMethod]
        public void WithdrawFunds_AmountGreaterThanBalance_ExceptionType()
        {
            // Arrange
            double beginningBalance = 11.99;
            double transaction_amt = 100.00;
            BankAccount account = new BankAccount("Ms Unite Testy", beginningBalance);

            // Act and Assert in simpler form:
            //      Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.WithdrawFunds(transaction_amt));

            // Act
            try
            {
                account.WithdrawFunds(transaction_amt);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert

                // the test compares two strings
                StringAssert.Contains(e.Message, BankAccount.Outcome_AmountExceedsBalance);
            }
        }

        [TestMethod]
        public void PayInFunds_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            BankAccount account = new BankAccount("Ms Unite Testy", beginningBalance);

            double transaction_amt = 4.00;
            double expectedBalance = 15.99;
            
            // Act
            account.PayInFunds(transaction_amt);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expectedBalance, actual, 0.001, "Account not credited correctly");
        }        

    }
}