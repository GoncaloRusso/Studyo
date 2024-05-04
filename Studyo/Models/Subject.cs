using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    /// <summary>
    /// Model for Subjects. Which are composed by several Chapters, each with their own topics regarding the same Subject.
    /// </summary>
    [Table("Subjects")]
    public class Subject
    {
        /// <summary>
        /// Id that identifies each unique Subject.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Subject
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Number of Chapters the Subject is composed of.
        /// </summary>
        [Required]
        public int NumberOfChapters { get; set; }

        /// <summary>
        /// NotMapped parameter which is used to load in a list all the Chapters for this Subject when needed to be shown/used.
        /// </summary>
        [NotMapped]
        public List<Chapter> Chapters { get; set; }
    }
}
    