namespace BullsAndCows.GameLogic.Contracts
{
    public interface IGuessResult
    {
        int BullCount { get; }
        int CowCount { get; }
        bool HasWon { get; }
    }
}
