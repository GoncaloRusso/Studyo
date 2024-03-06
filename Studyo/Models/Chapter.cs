using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{

    [Table("Chapters")]
    public class Chapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}