namespace Studyo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Quiz
    {
        [Required]
        public List<QuizQuestion> Questions { get; set; }

        [Key]
        public int QuizID { get; set; }
    }
}
