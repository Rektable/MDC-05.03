using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;
namespace BankTests
{

    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
            account.Debit(debitAmount));
        }


        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }


        [TestMethod]
        public void Credit_WithPositiveAmount_IncreasesBalance()
        {
            double initialBalance = 100.0;
            double creditAmount = 50.0;
            double expectedBalance = 150.0;
            BankAccount account = new BankAccount("Test User", initialBalance);
            account.Credit(creditAmount);
            Assert.AreEqual(expectedBalance, account.Balance, 0.001, "Balance after credit is incorrect");
        }

        [TestMethod]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            BankAccount account = new BankAccount("Test User", 100.0);
            double invalidAmount = -50.0;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Credit(invalidAmount));
        }

        [TestMethod]
        public void Constructor_InitializesNameAndBalance()
        {
            string expectedName = "John Doe";
            double expectedBalance = 500.75;
            BankAccount account = new BankAccount(expectedName, expectedBalance);
            Assert.AreEqual(expectedName, account.CustomerName, "Customer name was not initialized correctly");
            Assert.AreEqual(expectedBalance, account.Balance, 0.001, "Initial balance was not set correctly");
        }

        [TestMethod]
        public void Credit_WithZeroAmount_DoesNotChangeBalance()
        {
            double initialBalance = 200.50;
            BankAccount account = new BankAccount("Test User", initialBalance);
            account.Credit(0.0);
            Assert.AreEqual(initialBalance, account.Balance, 0.001, "Balance changed when credited with zero");
        }
    }
}