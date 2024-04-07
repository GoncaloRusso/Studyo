using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    [Table("UserChapters")]
    public class UserChapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ChapterId { get; set; }

        [ForeignKey("ChapterId")]
        public Chapter Chapter { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [NotMapped]
        public int CurrentScore { get; set; } = 0;

        [Required]
        public int BestGrade { get; set; } = 0;
    }
}
