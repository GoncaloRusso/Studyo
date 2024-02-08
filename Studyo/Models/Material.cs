namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Materials")]
    public class Material
    {
        [Key] public int Id { get; set; }
        [NotMapped] public AnkiCard AnkiCard { get; set; }

        [Required] public string Conteudo { get; set; }

        
        [Required] public int QuizId { get; set; }

        [ForeignKey("QuizId")]

        public virtual Quiz Quiz { get; set; }

        // Add the ChapterId foreign key
        [Required] public int ChapterId { get; set; }

        // Add the Chapter navigation property
        [ForeignKey("ChapterId")]
        public virtual Chapter Chapter { get; set; }
    }
}
