namespace Studyo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class QuizQuestion
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public Dictionary<bool, string> Answers { get; set; }

        [Key]
        public int QuestionID { get; set; }
    }
}
