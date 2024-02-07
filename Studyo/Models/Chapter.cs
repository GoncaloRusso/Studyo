namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Chapters")]
    public class Chapter
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [NotMapped] public Material[] Normal { get; set; }

        [Required] public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}
