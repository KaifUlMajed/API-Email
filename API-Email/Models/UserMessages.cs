﻿namespace API_Email.Models
{
    public class UserMessages : EntityBase
    {
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public int PlaceHolderId { get; set; }
    }
}
