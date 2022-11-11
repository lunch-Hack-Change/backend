namespace HackAndChangeApi.Models
{
    public class AuthUser
    {
        public string JwtTocken { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
    }
}
