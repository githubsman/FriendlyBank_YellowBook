/*
 * helped by 
 * https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022
 * 
 * https://learn.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2022
 * https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=visualstudiosdk-2022
   
    A test method must:
        - be decorated with the attribute [TestMethod]
        - not have parameters
        - return void
    In a test unit project, not all classes need be [TestClass] 
                        and not all methods need be [TestMethod].

    AAA pattern:
       Arrange:  Initialize objects and set arguments to be passed to the method under test.
       Act:       Invoke the method. 
       Assert:    Verify that the behavior and result is as expected.  
                   (a class could be used for managing the assertions.)
 */

//using Microsoft.VisualStudio.TestTools.UnitTesting;
//         Not needed: it's specified in ...\obj\Debug\net8.0\Bank_tests.GlobalUsings.g.cs
//             ... Visual Studio insists on this configuration.  


using FriendlyBank;  

namespace UnitTest
{
    [TestClass]
    public class JuniorAccount_test
    {

        [TestMethod]
        public void Test_AccountAllowed_good()
        {
            // Arrange
            decimal test_amt = 30;
            int test_age = 11;

            // Act and Assert
            Assert.IsTrue(JuniorAccount.AccountAllowed(age: test_age, transaction_amt: test_amt));
        }

        [TestMethod]
        public void Test_AccountAllowed_bad_age()
        {
            // Arrange
            decimal test_amt = 30;
            int test_age = 8;

            // Act and Assert    
            Assert.IsFalse(JuniorAccount.AccountAllowed(age: test_age, transaction_amt: test_amt));
        }


        [TestMethod]
        public void Test_AccountAllowed_bad_amt()
        {
            // Arrange
            decimal test_amt = 15;
            int test_age = 11;
        
            // Act and Assert    
            Assert.IsFalse(JuniorAccount.AccountAllowed(age: test_age, transaction_amt: test_amt));
        }
        
        [TestMethod]
        public void Test_GetBalance()
        {
            // Arrange
            decimal test_amt = 60;
            ICustomerAccount test = new JuniorAccount("Testy Junior", "Address", inAge: 15, inBalance: test_amt);
        
            // Act and Assert
            Assert.AreEqual(test_amt, test.GetBalance());
        }
    }



    [TestClass]
    public class CustomerAccount_test
    {
        [TestMethod]
        public void Test_GetBalance()
        {
            // Arrange
            decimal test_amt = 1050;
            ICustomerAccount test = new PersonalAccount("Testy Customer", "Address", 20, test_amt);

            // Act and Assert
            Assert.AreEqual(test_amt, test.GetBalance());
        }

        [TestMethod]
        public void Test_WithdrawFunds_good()
        {
            // Arrange
            decimal test_amt = 1050;
            ICustomerAccount test = new PersonalAccount("Testy Customer", "Address", 20, test_amt);
            test.PayInFunds(test_amt);

            // Act and Assert
            Assert.IsTrue(test.WithdrawFunds(test_amt - 1));
        }

        [TestMethod]
        public void Test_WithdrawFunds_bad_negative_bal()
        {
            // Arrange
            decimal test_amt = 1050;
            ICustomerAccount test = new PersonalAccount("Testy Customer", "Address", 20, test_amt);

            // Act and Assert
            Assert.IsFalse(test.WithdrawFunds(test_amt + 1));
        }

        [TestMethod]
        public void Test_PayInFunds_good()
        {
            // Arrange
            decimal test_amt = 1150;
            ICustomerAccount test = new PersonalAccount("Testy Customer", "Address", 42, test_amt);

            // Act
            test.PayInFunds(test_amt);

            // Assert
            Assert.AreEqual(test.GetBalance(), test_amt * 2);
        }
        
        [TestMethod]
        public void Test_AccountAllowed_good()
        {
            // Arrange
            decimal test_amt = 1100;
            int test_age = 20;

            // Act and Assert
            Assert.IsTrue(CustomerAccount.AccountAllowed(age: test_age, transaction_amt: test_amt));
        }

        [TestMethod]
        public void Test_AccountAllowed_bad_age()
        {
            // Arrange
            decimal test_amt = 5000;
            int test_age = 16;

            // Act and Assert      //#MARK named parameters, ex (transaction_amt: test_amt)
            Assert.IsFalse(CustomerAccount.AccountAllowed(age: test_age, transaction_amt: test_amt));
        }

        [TestMethod]
        public void Test_AccountAllowed_bad_starting_amt()
        {
            // Arrange
            decimal test_amt = 990;
            int test_age = 40;

            // Act and Assert
            Assert.IsFalse(CustomerAccount.AccountAllowed(test_amt, test_age));
        }


        /*  TODO  Reinstate use of precise exceptions. 
         * 
         *      These tests (very correctly) require a working (test) bank account - 
         *      hopefully Yellow Book 4.7 will get us there!
         *              

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double transactionAmount = 4.55;
            double expectedBalance = 7.44;
            ICustomerAccount test = new PersonalAccount("Ms Unite Testy", beginningBalance);

            // Act
            test.WithdrawFunds(transactionAmount);

            // Assert
            decimal actual = test.GetBalance;
            Assert.AreEqual(expectedBalance, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_AmountLessThanZero_ExceptionType()
        {
            // Arrange
            double beginningBalance = 11.99;
            double transactionAmount = -2.00;
            ICustomerAccount test = new PersonalAccount("Ms Unite Testy", beginningBalance);

            // Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => test.Debit(transactionAmount));
        }

        [TestMethod]
        public void Debit_AmountGreaterThanBalance_ExceptionType()
        {
            // Arrange
            double beginningBalance = 11.99;
            double transactionAmount = 100.00;
            ICustomerAccount test = new PersonalAccount("Ms Unite Testy", beginningBalance);

            // Act and Assert in simpler form:
            //      Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => test.Debit(transactionAmount));


            // Act
            try
            {
                test.Debit(transactionAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert

                // the test compares two strings
                StringAssert.Contains(e.Message, BankAccount.Outcome_AmountExceedsBalance);
            }
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            ICustomerAccount test = new CustomerAccount("Ms Unite Testy", beginningBalance);

            double transactionAmount = 4.00;
            double expectedBalance = 15.99;

            // Act
            test.Credit(transactionAmount);

            // Assert
            double actual = test.GetBalance;
            Assert.AreEqual(expectedBalance, actual, 0.001, "Account not credited correctly");
        }

        */
    }
}
