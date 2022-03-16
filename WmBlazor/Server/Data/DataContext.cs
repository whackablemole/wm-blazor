using Microsoft.EntityFrameworkCore;
using System.Text;

namespace WmBlazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        // Add references to entities that will be turned into tables in the database

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Developer> Developers { get; set;}

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Role adminRole = new Role { Id = 2, Name = "Admin" };

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Member" },
                adminRole

                );

            //var utf8 = new UTF8Encoding();
            //byte[] adminPass = utf8.GetBytes("PcmKz+eGlepKcK0B2LsScInUGH4+Zf/30Kublz3PCU04r1h91m+rp5KWGfJY+AqffcqpZaU3FSbKRyFgkb1Hjw==");
            //byte[] adminSalt = utf8.GetBytes("akWxmxUC0vrDdvByx1LFD0rMcBIZb36A52KMNZ9TF22iY7gvI1AZp6RMt7Guh+STS2/eDoxqJvmVOtSqsN6AJd6Irbx61qj3orLjzWn45iZaQs5Cq2voqfzFZeWvHnDNx34GWthDchTxcqqLrFEyz9L34WS0yA6Oxl4Qdd8dByY=");
            //modelBuilder.Entity<User>().HasData(
            //    new User { Username = "mtownsend", PasswordHash = adminPass, PasswordSalt = adminSalt, RoleId = 2 }
            //    );

            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "Colossal Order", Description = "Colossal order are a game developer" },
                new Developer { Id = 2, Name = "System Era Softworks", Description = "System Era Softworks is a small development studio led by veteran game developers headquartered in Seattle, Washington. We are currently working on our first game, Astroneer." },
                new Developer { Id = 3, Name = "BANDAI NAMCO Studios Inc.", Description = "A world famous games developer" },
                new Developer { Id = 4, Name = "Kunos Simulazioni", Description = "A games studio famous for their racing simulators" },
                new Developer { Id = 5, Name = "Developer: HB Studios Multimedia Ltd. ", Description = "Not as bad as EA" }
                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Paradox Interactive", Description = "We create the games. You create the stories." },
                new Publisher { Id = 2, Name = "System Era Softworks", Description = "System Era Softworks is a small development studio led by veteran game developers headquartered in Seattle, Washington. We are currently working on our first game, Astroneer." },
                new Publisher { Id = 3, Name = "BANDAI NAMCO Entertainment", Description = "BANDAI NAMCO Entertainment, is a leading interactive entertainment software publisher known for creating and publishing many of the industry top video game franchises." },
                new Publisher { Id = 4, Name = "505 Games", Description = "505 Games is a global game publisher focused on offering a broad selection of titles for players of all ages and levels." },
                new Publisher { Id = 5, Name = "2K", Description = "2K develops and publishes critically-acclaimed franchises such as BioShock, Borderlands, Sid Meier’s Civilization, XCOM, WWE 2K, and NBA 2K." }
                );

            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "Cities Skylines", Description = "A city-building game by Colossal Order", PriceGb = (decimal)22.99, DeveloperId = 1, PublisherId = 1 },
                new Game { Id = 2, Name = "Astroneer", Description = "A cute little space exploration game", PriceGb = (decimal)23.79, DeveloperId = 2, PublisherId = 2 },
                new Game { Id = 3, Name = "Ace Combat 7: Skies Unknown", Description = "A combat flight simulator by BANDAI NAMCO Studios Inc.", PriceGb = (decimal)49.99, DeveloperId = 3, PublisherId = 3 },
                new Game { Id = 4, Name = "Assetto Corsa Competizione", Description = "A racing simulator by Kunos Simulazoni", PriceGb = (decimal)34.99, DeveloperId = 4, PublisherId = 4 },
                new Game { Id = 5, Name = "PGA Tour 2K21", Description = "A golf simulator", PriceGb = (decimal)49.99, DeveloperId = 5, PublisherId = 5 }
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Flight" },
                new Tag { Id = 2, Name = "Jet" },
                new Tag { Id = 3, Name = "Military" },
                new Tag { Id = 4, Name = "War" },
                new Tag { Id = 5, Name = "Shooter" },
                new Tag { Id = 6, Name = "Arcade" },
                new Tag { Id = 7, Name = "City Builder" },
                new Tag { Id = 8, Name = "Simulation" },
                new Tag { Id = 9, Name = "Building" },
                new Tag { Id = 10, Name = "Sports" },
                new Tag { Id = 11, Name = "Local Multiplayer" },
                new Tag { Id = 12, Name = "Multiplayer" },
                new Tag { Id = 13, Name = "Open World" },
                new Tag { Id = 14, Name = "Racing" },
                new Tag { Id = 15, Name = "Automobile Sim" },
                new Tag { Id = 16, Name = "VR" },
                new Tag { Id = 17, Name = "Golf" }
                );

            //modelBuilder.Entity<GameTag>().HasKey(new string[] { "TagsName", "GamesId" });
            //modelBuilder.Entity<GameTag>().HasData(
            //    new GameTag { TagsName = "City Builder", GamesId = 1},
            //    new GameTag { TagsName = "Simulation", GamesId = 1},
            //    new GameTag { TagsName = "Building", GamesId = 1},
            //    new GameTag { TagsName = "Multiplayer", GamesId = 2},
            //    new GameTag { TagsName = "Open World", GamesId = 2},
            //    new GameTag { TagsName = "Flight", GamesId = 3},
            //    new GameTag { TagsName = "Jet", GamesId = 3},
            //    new GameTag { TagsName = "Military", GamesId = 3},
            //    new GameTag { TagsName = "War", GamesId = 3},
            //    new GameTag { TagsName = "Shooter", GamesId = 3},
            //    new GameTag { TagsName = "Racing", GamesId = 4},
            //    new GameTag { TagsName = "Automobile Sim", GamesId = 4},
            //    new GameTag { TagsName = "VR", GamesId = 4},
            //    new GameTag { TagsName = "Sports", GamesId = 5},
            //    new GameTag { TagsName = "Golf", GamesId = 5},
            //    new GameTag { TagsName = "Simulation", GamesId = 5}
            //    );
        }
    }
}
