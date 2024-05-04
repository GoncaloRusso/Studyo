using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    /// <summary>
    /// WORK IN PROGRESS!!!
    /// Model for Workshops
    /// </summary>
    public class Workshop
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Title of the Workshop
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Description of the workshop
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Content of the Workshop represented by the Model Class WorkshopContent
        /// </summary>
        [Required, ForeignKey("WorkshopContent")]
        public WorkshopContent Content { get; set; }

        /// <summary>
        /// Date of creation
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// Date of update
        /// </summary>
        [Required]
        public DateTime Updated { get; set; }

    }
}