using Microsoft.EntityFrameworkCore;
using System.Text;

namespace WmBlazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Role adminRole = new Role { Id = 2, Name = "Admin" };

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Member"},
                adminRole
               
                );


            var utf8 = new UTF8Encoding();
            byte[] adminPass = utf8.GetBytes("PcmKz+eGlepKcK0B2LsScInUGH4+Zf/30Kublz3PCU04r1h91m+rp5KWGfJY+AqffcqpZaU3FSbKRyFgkb1Hjw==");
            byte[] adminSalt = utf8.GetBytes("akWxmxUC0vrDdvByx1LFD0rMcBIZb36A52KMNZ9TF22iY7gvI1AZp6RMt7Guh+STS2/eDoxqJvmVOtSqsN6AJd6Irbx61qj3orLjzWn45iZaQs5Cq2voqfzFZeWvHnDNx34GWthDchTxcqqLrFEyz9L34WS0yA6Oxl4Qdd8dByY=");
            modelBuilder.Entity<User>().HasData(
                new User { Username = "mtownsend", PasswordHash = adminPass, PasswordSalt = adminSalt, RoleId = 2 }
                );
        }

        // Add references to entities that will be turned into tables in the database

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
