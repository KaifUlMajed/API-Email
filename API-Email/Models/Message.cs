namespace API_Email.Models
{
    using System;

    public class Message : EntityBase
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentDate { get; set; }
    }
}
