using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studyo.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {

    }
}
