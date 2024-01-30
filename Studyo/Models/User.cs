namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Required]
        public Account Account { get; set; }

        public bool IsConnected { get; set; }

        [Required]
        public UserType UserType { get; set; }
    }
}
