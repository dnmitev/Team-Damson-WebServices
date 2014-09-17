namespace BullsAndCows.Data.Contracts
{
    using System;
    using System.Linq;

    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IGenericRepository<Player> Players { get; }

        IGenericRepository<Game> Games { get; }

        IGenericRepository<GuessNumber> GuessNumbers { get; }

        void SaveChanges();
    }
}