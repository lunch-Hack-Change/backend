using Microsoft.EntityFrameworkCore;

namespace HackAndChangeApi.Models
{
    public class HackAndChangeContext : DbContext
    {
        public HackAndChangeContext(DbContextOptions<HackAndChangeContext> options)
            : base(options)
        {

        }

        public DbSet<Share> Shares { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
