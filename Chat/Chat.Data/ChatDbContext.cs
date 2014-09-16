namespace Chat.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Chat.Models;
    using Chat.Data.Contracts;

    public class ChatDbContext : DbContext, IChatDBContext
    {
        public ChatDbContext()
            : this("DefaultConnection")
        {
        }

        public ChatDbContext(string connectionstring)
            : base(connectionstring)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatDbContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<ChatDbContext>());
        }

        public IDbSet<Attachment> Attachments { get; set; }

        public IDbSet<Message> Messages { get; set; }

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