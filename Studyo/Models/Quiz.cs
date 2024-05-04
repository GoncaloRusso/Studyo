using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    /// <summary>
    /// Model for Quiz. Which are a fundamental part of a Chapter for the user to apply its learnd contents. It is also composed by several questions, which each are also
    /// composed of different answers.
    /// </summary>
    [Table("Quizzes")]
    public class Quiz
    {
        /// <summary>
        /// Id that identifies each unique Quiz.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Chapter Id that Identifies which Chapter the Quiz belongs too.
        /// </summary>
        [Required]
        public int ChapterId { get; set; }

        /// <summary>
        /// Chapter to which the ChapterId belongs
        /// </summary>
        [ForeignKey("ChapterId")]
        public virtual Chapter Chapter { get; set; }

        /// <summary>
        /// NotMapped parameter which is used to load in a list all the quiz questions for this quiz when needed to be shown.
        /// </summary>
        [NotMapped]
        public List<QuizQuestion> QuizQuestions { get; set; }
    }
}