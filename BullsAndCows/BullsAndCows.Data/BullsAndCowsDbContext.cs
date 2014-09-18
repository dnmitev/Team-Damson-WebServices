namespace BullsAndCows.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Data.Migrations;
    using BullsAndCows.Models;

    public class BullsAndCowsDbContext : IdentityDbContext<Player>
    {
        public BullsAndCowsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<GuessNumber> GuessNumbers { get; set; }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }
    }
}