namespace Chat.Models
{
    using System;
    using System.Collections.Generic;

    public class Message
    {
        private ICollection<Attachment> attachments;

        public Message()
        {
            this.Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }

        public DateTime DateOfSent { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Attachment> Attachments
        {
            get
            {
                return this.attachments;
            }

            set
            {
                this.attachments = value;
            }
        }
    }
}