namespace BullsAndCows.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public class BullsAndCowsData : IBullsAndCowsData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public BullsAndCowsData()
            : this(new BullsAndCowsDbContext())
        {
        }

        public BullsAndCowsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Player> Players
        {
            get
            {
                return this.GetRepository<Player>();
            }
        }

        public IGenericRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IGenericRepository<GuessNumber> GuessNumbers
        {
            get
            {
                return this.GetRepository<GuessNumber>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}