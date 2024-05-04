using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    /// <summary>
    /// Model for QuizQuestion. Which are a fundamental part of a Quiz, for they are the questions that are part of a Quiz the user will answer. Each quiz question has also several
    /// Answers (QuizQuestionAnswer)
    /// </summary>
    [Table("QuizQuestions")]
    public class QuizQuestion
    {

        /// <summary>
        /// Id that identifies each unique QuizQuestion.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Text of this question
        /// </summary>
        [Required]
        public string Question { get; set; }

        /// <summary>
        /// Id of the Quiz this Question belongs too.
        /// </summary>
        [Required]
        public int QuizId { get; set; }

        /// <summary>
        /// Quiz to which the QuizId belongs
        /// </summary>
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        /// <summary>
        /// NotMapped parameter which is used to load in a list all the answers for this quiz question when needed to be shown.
        /// </summary>
        [NotMapped]
        public List<QuizQuestionAnswer> Answers { get; set; }
    }
}