namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Quizzes")]
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
    }
}