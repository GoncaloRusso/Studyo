using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    [Table("UsersSubjects")]
    [PrimaryKey(nameof(ChapterId), nameof(UserId))]
    public class UserCompletedChapters
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ChapterId")]
        public int ChapterId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [NotMapped]
        public Dictionary<Chapter, bool> CompletedChapters {  get; set; }

        public int calculateCompletion() {
            return CompletedChapters.Where(i => i.Value == true).Count() / CompletedChapters.Count();
        }
    }
}
