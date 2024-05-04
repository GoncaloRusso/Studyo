using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    /// <summary>
    /// Model for UserSubject, which is a class responsable for managing the interactions of the users with the different subjects.
    /// Creating a different UserSubject for each user the first time they open a Subject for the first time
    /// </summary>
    [Table("UserSubjects")]
    public class UserSubject
    {
        /// <summary>
        /// Id that identifies each unique UserSubject.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id of the Subject in this relation between the User and the Subject
        /// </summary>
        [Required]
        public int SubjectId { get; set; }

        /// <summary>
        /// Subject to which the SubjectId belongs too.
        /// </summary>
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        /// <summary>
        /// Id of the User in this relation between the User and the Subject
        /// </summary>
        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        /// <summary>
        /// NotMapped value used to calculate when needed to be shown, the number of chapters the user has completed on this Subject.
        /// </summary>
        [NotMapped]
        public int NumberOfCompletedChapters;

        /// <summary>
        /// A NotMapped percentage like value used to calculate the completion percentage of chapters for this user on this subject
        /// </summary>
        [NotMapped]
        public float Completion;

        /// <summary>
        /// NotMapped parameter which is used to load in a list all the UserChapter instances for the matching of this User and Subject when needed to be shown/used
        /// </summary>
        [NotMapped]
        public List<UserChapter> UserChapters { get; set; }
    }
}
