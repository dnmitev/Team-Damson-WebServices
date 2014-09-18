namespace BullsAndCows.GameLogic
{
    using BullsAndCows.Data.Contracts;
    using BullsAndCows.GameLogic.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGameDataValidator
    {
        IGuessResult GetResult(IGuess guess, IBullsAndCowsData data);
    }
}