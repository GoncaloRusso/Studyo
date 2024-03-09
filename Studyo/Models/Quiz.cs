using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{

    [Table("Quizzes")]
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ChapterId { get; set; }

        [ForeignKey("ChapterId")]
        public virtual Chapter Chapter { get; set; }

        [NotMapped]
        public List<QuizQuestion> QuizQuestions { get; set; }
    }
}