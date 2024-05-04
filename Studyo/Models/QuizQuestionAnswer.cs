using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Studyo.Models
{
    /// <summary>
    /// Model for QuizQuestionAnswer. Which are a fundamental part of a QuizQuestion, for they are the answers that are part of a QuizQuestion the user will answer.
    /// </summary>
    public class QuizQuestionAnswer
    {

        /// <summary>
        /// Id that identifies each unique QuizQuestionAnswer.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Text of the answer
        /// </summary>
        [Required]
        public string Answer { get; set; }

        /// <summary>
        /// Boolean that identifies if the answer is correct (true) or wrong (false)
        /// </summary>
        [Required]
        public bool isCorrectAnswer { get; set; }

        /// <summary>
        /// Id of the QuizQuestion this Answer belongs too.
        /// </summary>
        [Required]
        public int QuizQuestionId { get; set; }

        /// <summary>
        /// QuizQuestion to which the QuizQuestionId belongs
        /// </summary>
        [ForeignKey("QuizQuestionId")]
        public virtual QuizQuestion QuizQuestion { get; set; }
    }
}
