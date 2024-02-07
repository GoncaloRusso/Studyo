namespace Studyo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Quizzes")]
    public class Quiz
    {
        [Key] public int Id { get; set; }

        [NotMapped] public List<QuizQuestion> Questions { get; set; }
    }
}