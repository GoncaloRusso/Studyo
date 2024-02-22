using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Studyo.Models
{
    public class WorkshopContent
    {
        [Key]
        [ForeignKey("Workshop")]
        public int Id { get; set; }

        [Required]
        public Workshop workshop { get; set; }
    }
}