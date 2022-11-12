using System.ComponentModel.DataAnnotations;

namespace HackAndChangeApi.Models
{
    public class AuthUser
    {
        [Key]
        public int AuthUserId { get; set; }
        [Required]
        public string JwtTocken { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
