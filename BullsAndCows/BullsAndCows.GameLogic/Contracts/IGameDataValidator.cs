﻿namespace BullsAndCows.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGameDataValidator
    {
        GameResult GetResult(int guessNumber);
    }
}