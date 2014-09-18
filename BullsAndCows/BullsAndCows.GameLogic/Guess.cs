namespace BullsAndCows.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BullsAndCows.GameLogic.Contracts;

    public class Guess : IGuess
    {
        public string GuessingUserId
        {
            get;
            set;
        }

        public string GuessNumber
        {
            get;
            set;
        }
    }
}
