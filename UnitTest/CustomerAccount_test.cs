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

    MARK AAA pattern:  Arrange, Act, Test
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
    public class PersonalAccount_test
    {
        [TestMethod]
        public void Test_GetBalance()
        {
            // Arrange
            decimal test_amt = 1050;
            ICustomerAccount test = new PersonalAccount(20, test_amt);

            // Act and Assert
            Assert.AreEqual(test_amt, test.GetBalance());
        }

        [TestMethod]
        public void Test_WithdrawFunds_good()
        {
            // Arrange
            decimal test_amt = 1050;
            ICustomerAccount test = new PersonalAccount(20, test_amt);
            test.PayInFunds(test_amt);

            // Act and Assert
            Assert.IsTrue(test.WithdrawFunds(test_amt - 1));
        }

        [TestMethod]
        public void Test_WithdrawFunds_bad_negative_bal()
        {
            // Arrange
            decimal test_opening_balance = 1040;
            decimal test_amt_bad = 1050;
            ICustomerAccount test = new PersonalAccount(20, test_opening_balance);

            // Act
            try    { test.WithdrawFunds(test_amt_bad); }

            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert      ... the test compares two strings
                StringAssert.Contains(e.Message, test.Err_AmtExceedsBalance);
            }

            // ALTERNATE, COMPACT:       // Act and Assert:
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => test.WithdrawFunds(test_amt_bad));

        }

        [TestMethod]
        public void Test_WithdrawFunds_bad_negative_transaction_amt()
        {
            // Arrange
            decimal test_opening_balance = 1000;
            decimal test_amt_bad = -10;
            ICustomerAccount test = new PersonalAccount(20, test_opening_balance);

            // Act
            try    {    test.WithdrawFunds(test_amt_bad);    }

            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert      ... the test compares two strings
                StringAssert.Contains(e.Message, test.Err_AmtSubZero);
            }

            // Act and Assert
            //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => test.WithdrawFunds(test_amt_bad));
        }

        [TestMethod]
        public void Test_PayInFunds_good()
        {
            // Arrange
            decimal test_opening_balance = 1000m;
            decimal test_amt = 4.55m;
            decimal expectedBalance = test_opening_balance + test_amt;
            ICustomerAccount test = new PersonalAccount("Louie", "The Bronx", 42, test_opening_balance);

            // Act
            test.PayInFunds(test_amt);

            // Assert
            Assert.AreEqual(test.GetBalance(), expectedBalance, "Account not credited correctly");
        }
        
        [TestMethod]
        public void Test_NewAccount_good()
        {
            // Arrange
            decimal test_amt = 1100;
            int test_age = 42;

            // Act and Assert
            Assert.IsTrue(PersonalAccount.AccountAllowed(age: test_age, transaction_amt: test_amt));
        }

        [TestMethod]
        public void Test_NewAccount_bad_age()
        {
            // Arrange
            decimal test_amt = 5000;
            int test_age_bad = 16;

            // Act and Assert      //#MARK named parameters, ex (transaction_amt: test_amt)
            Assert.IsFalse(PersonalAccount.AccountAllowed(age: test_age_bad, transaction_amt: test_amt));

        }

        [TestMethod]
        public void Test_NewAccount_bad_starting_amt()
        {
            // Arrange
            decimal test_amt_bad = 990;
            int test_age = 40;

            // Act and Assert
            Assert.IsFalse(PersonalAccount.AccountAllowed(age: test_age, transaction_amt: test_amt_bad));
        }

    }

    [TestClass]
    public class JuniorAccount_test
    {

        [TestMethod]
        public void Test_NewAccount_good()
        {
            // Arrange
            decimal test_amt = 110;
            int test_age = 11;

            // Act and Assert
            Assert.IsTrue(JuniorAccount.AccountAllowed(age: test_age, transaction_amt: test_amt));
        }

        [TestMethod]
        public void Test_NewAccount_bad_age()
        {
            // Arrange
            decimal test_amt = 30;
            int test_age_bad = 8;

            // Act and Assert    
            Assert.IsFalse(JuniorAccount.AccountAllowed(age: test_age_bad, transaction_amt: test_amt));
        }


        [TestMethod]
        public void Test_NewAccount_bad_amt()
        {
            // Arrange
            decimal test_amt_bad = 15;
            int test_age = 11;

            // Act and Assert    
            Assert.IsFalse(JuniorAccount.AccountAllowed(age: test_age, transaction_amt: test_amt_bad));
        }

        [TestMethod]
        public void Test_GetBalance()
        {
            // Arrange
            decimal test_amt = 120;
            ICustomerAccount test = new JuniorAccount(inAge: 15, inBalance: test_amt);

            // Act and Assert
            Assert.AreEqual(test_amt, test.GetBalance());
        }
    }
}
