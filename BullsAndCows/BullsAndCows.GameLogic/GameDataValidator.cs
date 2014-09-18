namespace BullsAndCows.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity.EntityFramework;

    using BullsAndCows.Data;
    using BullsAndCows.Data.Contracts;
    using BullsAndCows.GameLogic.Contracts;
    using BullsAndCows.Models;

    public class GameDataValidator : IGameDataValidator
    {
        public GameResult GetResult(int guessNumber)
        {
            throw new NotImplementedException();
        }

        public IGuessResult GetResult(IGuess guess, IBullsAndCowsData data)
        {
            var guessingPlayer = data.Players.All()
                .FirstOrDefault(x => x.Id == guess.GuessingUserId);

            if (guessingPlayer == null)
            {
                throw new ArgumentException("Player cant be found. Make sure the given user id is correct.");
            }

            var currentGame = data.Games.All()
                .FirstOrDefault(x => (x.FirstPlayerId == guessingPlayer.Id || x.SecondPlayerId == guessingPlayer.Id) &&
                x.State == GameState.FirstPlayerTurn || x.State == GameState.SecondPlayerTurn);

            if (currentGame == null)
            {
                throw new Exception("The current player game is invalid");
            }

            int? secretNumber;
            if (currentGame.FirstPlayerId == guess.GuessingUserId)
            {
                secretNumber = currentGame.SecondPlayerSecretNumber;
            }
            else
            {
                secretNumber = currentGame.FirstPlayerSecretNumber;
            }

            var result = this.CompareToSecret(secretNumber.ToString(), guess.GuessNumber.ToString());

            if (result.HasWon)
            {
                if (currentGame.FirstPlayerId == guess.GuessingUserId)
                {
                    result.GameResult = GameResult.WonByFirstPlayer;
                }
                else
                {
                    result.GameResult = GameResult.WonBySecondPlayer;
                }
            }

            return result;
        }

        public IGuessResult CompareToSecret(string secret, string guess)
        {
            //TODO: A stricter validation can be put here. I don't validate for repeating syllabus for instance
            if (secret.Length != guess.Length)
            {
                throw new ArgumentException("The guess is invalid. Its length doesn't match the secrets length.");
            }

            int bulls = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
            }

            //I will implement it so that it works with repeating symbols
            //Couldn't hurt
            //Calculating cows
            var secretSymbols = new Dictionary<char, int>();
            for (int i = 0; i < secret.Length; i++)
            {
                if (secretSymbols.ContainsKey(secret[i]))
                {
                    secretSymbols[secret[i]]++;
                }
                else
                {
                    secretSymbols[secret[i]] = 1;
                }
            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (secretSymbols.ContainsKey(guess[i]) && secretSymbols[guess[i]] > 0)
                {
                    secretSymbols[guess[i]]--;
                }
            }

            var cows = secret.Length - secretSymbols.Values.Sum() - bulls;
            var isGaveOver = bulls == secret.Length;
            var result = new GuessResult
            {
                BullCount = bulls,
                CowCount = cows,
                HasWon = isGaveOver,
                GameResult = GameResult.NotFinished
            };

            return result;
        }
    }
}