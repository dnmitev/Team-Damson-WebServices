namespace BullsAndCows.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using BullsAndCows.Models;

    public interface IBullsAndCowsDbContext
    {
        IDbSet<Player> Players { get; set; }

        IDbSet<Game> Games { get; set; }

        IDbSet<GuessNumber> GuessNumbers { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}