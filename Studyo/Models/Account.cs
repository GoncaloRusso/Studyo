namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Account
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Key]
        public int AccountId { get; set; }
    }
}
