namespace BullsAndCows.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.GameLogic.Contracts;

    public interface IGameDataValidator
    {
        IGuessResult GetResult(IGuess guess, IBullsAndCowsData data);
    }
}