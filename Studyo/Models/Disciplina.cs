namespace Studyo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Disciplina
    {
        public HashSet<Capitulo> Capitulo { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
