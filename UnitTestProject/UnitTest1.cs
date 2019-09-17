using System;
using DragonRageFlight;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Empty_Payout()
        {
            // Arrange
            var bet = new Bet();

            // Act
            var actual = bet.CashOut(1);

            // Asset
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Not_Enough_Cash_Message()
        {
            // Arrange
            var guy = new Bettor();

            // Act
            var actual = guy.Betting(1, 1);

            // Assert
            Assert.AreEqual(false, actual);
        }
    }
}
