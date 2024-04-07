using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    [Table("UserSubjects")]
    public class UserSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [NotMapped]
        public int NumberOfChapters;

        [NotMapped]
        public int NumberOfCompletedChapters;

        [NotMapped]
        public List<UserChapter> UserChapters { get; set; }
    }
}
