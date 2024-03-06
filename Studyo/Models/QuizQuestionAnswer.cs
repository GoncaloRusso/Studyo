using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Studyo.Models
{
    public class QuizQuestionAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public bool isCorrectAnswer { get; set; }

        [Required]
        public int QuizQuestionId { get; set; }

        [ForeignKey("QuizQuestionId")]
        public virtual QuizQuestion QuizQuestion { get; set; }
    }
}
