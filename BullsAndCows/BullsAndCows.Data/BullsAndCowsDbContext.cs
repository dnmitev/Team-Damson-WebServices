﻿namespace BullsAndCows.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Models;
    using BullsAndCows.Data.Migrations;

    public class BullsAndCowsDbContext : IdentityDbContext<Player>
    {
        public BullsAndCowsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        //public IDbSet<Player> Players { get; set; }

        public IDbSet<Game> Games { get; set; }

        //public IDbSet<GuessNumber> GuessNumbers { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        
        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}