﻿namespace JobPortal.Api.Models
{
    public class UserLanguage
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int LanguageId { get; set; }
        public Language? Language { get; set; }
    }
}
