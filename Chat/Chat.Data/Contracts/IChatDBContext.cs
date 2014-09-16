namespace Chat.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Chat.Models;

    public interface IChatDBContext
    {
        IDbSet<Attachment> Attachments { get; set; }

        IDbSet<Message> Messages { get; set; }


        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}