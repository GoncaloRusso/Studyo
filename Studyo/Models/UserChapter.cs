using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    /// <summary>
    /// Model for UserChapter, which is a class responsable for managing and saving the results of the interactions of the users with the different chapters.
    /// Creating a different userchapter for each user the first time they complete the quiz of different chapters
    /// </summary>
    [Table("UserChapters")]
    public class UserChapter
    {

        /// <summary>
        /// Id that identifies each unique UserChapter.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id of the Chapter in this relation between the User and the Chapter
        /// </summary>
        [Required]
        public int ChapterId { get; set; }

        /// <summary>
        /// Chapter to which the ChapterId belongs too.
        /// </summary>
        [ForeignKey("ChapterId")]
        public Chapter Chapter { get; set; }

        /// <summary>
        /// Id of the User in this relation between the User and the Chapter
        /// </summary>
        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        /// <summary>
        /// NotMapped parameter which is used to save the score the user obtains after finishing a Quiz.
        /// </summary>
        [NotMapped]
        public int CurrentScore { get; set; } = 0;

        /// <summary>
        /// Parameter used to save the best score the user has ever achieved submiting the quiz of the chapter.
        /// </summary>
        [Required]
        public int BestGrade { get; set; } = 0;
    }
}
