using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.GameLogic;

namespace BulsAndCows.GameLogic.Tests
{
    [TestClass]
    public class GuessComparerer
    {
        [TestMethod]
        public void ShouldGeneralyWork()
        {
            var gameLogic = new GameDataValidator();
            var guessResult = gameLogic.CompareToSecret("1234", "4231");
            Assert.AreEqual(guessResult.BullCount, 2, "The number of bulls was miscalculated");
            Assert.AreEqual(guessResult.CowCount, 2, "Cows was miscalculated.");
            Assert.IsFalse(guessResult.HasWon, "The game was prematurely ended");
        }

        [TestMethod]
        public void ShouldRecognizeVictory()
        {
            var gameLogic = new GameDataValidator();
            var guessResult = gameLogic.CompareToSecret("1234", "1234");
            Assert.AreEqual(guessResult.BullCount, 4, "The number of bulls was miscalculated");
            Assert.AreEqual(guessResult.CowCount, 0, "Cows was miscalculated.");
            Assert.IsTrue(guessResult.HasWon, "Victory wasn't recognized");
        }

        [TestMethod]
        public void ShouldRecognizeFailedGuesses()
        {
            var gameLogic = new GameDataValidator();
            var guessResult = gameLogic.CompareToSecret("5678", "1234");
            Assert.AreEqual(guessResult.BullCount, 0, "The number of bulls was miscalculated");
            Assert.AreEqual(guessResult.CowCount, 0, "Cows was miscalculated.");
            Assert.IsFalse(guessResult.HasWon, "The game was prematurely ended");
        }

    }
}
