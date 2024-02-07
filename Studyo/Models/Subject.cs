namespace Studyo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Subjects")]
    public class Subject
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        // Remova o atributo NotMapped
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
