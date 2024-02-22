namespace Studyo.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DisciplinaUsers")]
    [PrimaryKey(nameof(DisciplinaId), nameof(UserId))]
    public class DisciplinaUser
    {
        [Required]
        [ForeignKey("SubjetdId")]
        public int DisciplinaId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [NotMapped]
        public Dictionary<Chapter, bool> MaterialComp {  get; set; }

        public int percentagemFim() {
            return MaterialComp.Where(i => i.Value == true).Count() / MaterialComp.Count();
        }
    }
}
