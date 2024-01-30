namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AnkiCard
    {
        [Key]
        public int AnkiCardID { get; set; }

        [Required]
        public string Phrase { get; set; }

        [Required]
        public string Completion { get; set; }
    }
}
