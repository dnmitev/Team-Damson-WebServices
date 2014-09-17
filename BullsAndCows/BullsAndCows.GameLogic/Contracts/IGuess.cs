namespace BullsAndCows.GameLogic.Contracts
{
    public interface IGuess
    {
        string GuessingUserId { get; }
        string Guess { get; }
    }
}
