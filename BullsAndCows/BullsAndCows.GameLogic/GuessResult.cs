namespace BullsAndCows.GameLogic
{
    using BullsAndCows.GameLogic.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class GuessResult:IGuessResult
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
