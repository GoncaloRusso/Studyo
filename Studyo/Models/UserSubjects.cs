using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    [Table("UsersSubjects")]
    [PrimaryKey(nameof(SubjetdId), nameof(UserId))]
    public class UserSubjects
    {
        [Required]
        [ForeignKey("SubjetdId")]
        public int SubjetdId { get; set; }

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
