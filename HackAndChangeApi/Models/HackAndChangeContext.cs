using Microsoft.EntityFrameworkCore;

namespace HackAndChangeApi.Models
{
    public class HackAndChangeContext : DbContext
    {
        public HackAndChangeContext(DbContextOptions<HackAndChangeContext> options)
            : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Vidget> Vidgets { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
