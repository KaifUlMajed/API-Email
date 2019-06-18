namespace API_Email.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User : EntityBase
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
