namespace BullsAndCows.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BullsAndCows.GameLogic.Contracts;

    public class GuessResult : IGuessResult
    {
        public int BullCount
        {
            get;
            set;
        }

        public int CowCount
        {
            get;
            set;
        }

        public bool HasWon
        {
            get;
            set;
        }

        public GameResult GameResult { get; set; }
    }
}
