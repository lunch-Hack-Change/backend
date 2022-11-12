using System.ComponentModel.DataAnnotations;

namespace HackAndChangeApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }

    }
}
