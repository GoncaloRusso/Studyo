namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Capitulo
    {
        public Material[] Normal { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
