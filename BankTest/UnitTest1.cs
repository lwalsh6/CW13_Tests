using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//Logan Walsh
//4-20-2023
//This program is meant to try test cases for an existing program


namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        // unit test code  
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Credit_WhenCreditIsFrozen_ExceptionIsThrown()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            
            account.ToggleFreeze();

            account.Credit(creditAmount);
        }

        [TestMethod]
        public void Credit_WhenCreditIsNegative_ArgumentOutOfRangeIsThrown()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.CreditAmountIsNegative);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void Credit_WhenEverythingIsHunkyDory_UpdateAccount()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 25.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            account.Credit(creditAmount);
        }
        }
    }
