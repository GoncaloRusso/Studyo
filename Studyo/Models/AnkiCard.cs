namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AnkiCards")]
    public class AnkiCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Phrase { get; set; }

        [Required]
        public string Completion { get; set; }
    }
}
