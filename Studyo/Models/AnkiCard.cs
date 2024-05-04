using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    /// <summary>
    /// WORK IN PROGRESS!!!
    /// Model for AnkiCards
    /// </summary>
    [Table("AnkiCards")]
    public class AnkiCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        public string Phrase { get; set; }

        [Required]
        public string Completion { get; set; }
    }
}