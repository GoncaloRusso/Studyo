namespace Studyo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("QuizQuestions")]
    public class QuizQuestion
    {
        [Key]
        [ForeignKey("Quiz")]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [NotMapped]
        public Dictionary<bool, string> Answers { get; set; }
    }
}