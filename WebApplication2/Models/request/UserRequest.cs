
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class UserRequest
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(250)]
        public string Password { get; set; } 
    }
}
