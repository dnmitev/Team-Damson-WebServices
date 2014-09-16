namespace Chat.Models
{
    using System.Collections.Generic;

    public class Attachment
    {
        private ICollection<Message> messages;

        public Attachment()
        {
            this.Messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}