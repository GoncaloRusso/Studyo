namespace Studyo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Material
    {
        public Cards[] Cards { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
