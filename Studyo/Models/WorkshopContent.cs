using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Studyo.Models
{
    /// <summary>
    /// WORK IN PROGRESS!!!
    /// Model for WorkshopContent
    /// </summary>
    public class WorkshopContent
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        [ForeignKey("Workshop")]
        public int Id { get; set; }

        /// <summary>
        /// Belonging workshop
        /// </summary>
        [Required]
        public Workshop workshop { get; set; }
    }
}