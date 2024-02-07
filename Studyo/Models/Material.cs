namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Materials")]
    public class Material
    {
        [Key] public int Id { get; set; }
        [NotMapped]public AnkiCard AnkiCard { get; set; }
        
        [Required] public string File { get; set; }
        [Required] public Quiz Quiz { get; set; }
    }
}
