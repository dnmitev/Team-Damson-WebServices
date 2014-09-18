namespace BullsAndCows.GameLogic.Contracts
{
    public interface IGuess
    {
        string GuessingUserId { get; set; }
        string Guess { get; set; }
    }
}
