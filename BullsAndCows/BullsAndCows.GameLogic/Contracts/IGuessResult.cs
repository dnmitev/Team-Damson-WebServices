namespace BullsAndCows.GameLogic.Contracts
{
    public interface IGuessResult
    {
        int BullCount { get; set; }

        int CowCount { get; set; }

        bool HasWon { get; set; }

        GameResult GameResult { get; set; }
    }
}
