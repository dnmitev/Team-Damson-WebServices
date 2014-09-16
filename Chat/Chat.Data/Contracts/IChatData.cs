namespace Chat.Data.Contracts
{
    using System;
    using System.Linq;

    using Chat.Models;

    public interface IChatData
    {
        IGenericRepository<Attachment> Attachments { get; }

        IGenericRepository<Message> Messages { get; }
    }
}