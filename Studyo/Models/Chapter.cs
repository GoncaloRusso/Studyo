using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    /// <summary>
    /// Model for Chapters. Which are part a unique Subject and contain the content for the user to study
    /// </summary>
    [Table("Chapters")]
    public class Chapter
    {
        /// <summary>
        /// Id that identifies each unique chapter.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Chapter
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Text of the content of the chapter
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// Id of the Subject the Chapter belongs too.
        /// </summary>
        [Required]
        public int SubjectId { get; set; }

        /// <summary>
        /// Subject to which the SubjectId belongs
        /// </summary>
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}