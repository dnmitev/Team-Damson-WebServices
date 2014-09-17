namespace BullsAndCows.Models
{
    using System;
    using System.Linq;

    public enum GameState
    {
        WaitingForPlayer,
        FirstPlayerTurn,
        SecondPlayerTurn,
        WonByFirstPlayer,
        WonBySecondPlayer
    }
}