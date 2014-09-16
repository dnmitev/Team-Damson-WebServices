namespace Chat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Chat.Data.Contracts;
    using Chat.Data.Repositories;
    using Chat.Models;

    public class ChatData
    {
        private readonly IChatDBContext context;
        private readonly IDictionary<Type, object> repositories;

        public  ChatData()
            : this(new ChatDbContext())
        {
        }

        public  ChatData(string connectionString)
            : this(new ChatDbContext(connectionString))
        {
        }

        public  ChatData(IChatDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Attachment> Attachments
        {
            get
            {
                return this.GetRepository<Attachment>();
            }
        }

        public IGenericRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
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