using Games.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Games.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                    new Category { Id = 2, Name = "Horor", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "RPG", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product 
                    { 
                        Id = 1,
                        Title = "Pubg",
                        Description = "LAND, LOOT, SURVIVE! Play PUBG: BATTLEGROUNDS for free. Land on strategic locations, loot weapons and supplies, and survive to become the last team standing across various, diverse Battlegrounds. Squad up and join the Battlegrounds for the original Battle Royale experience that only PUBG: BATTLEGROUNDS can offer.", 
                        Developer = "KRAFTON, Inc.",
                        Publisher = "KRAFTON, Inc.",
                        ReleaseDate = new DateTime(2017, 12, 21),
                        ListPrice = 98,
                        Price = 68,
                        Price50 = 62,
                        Price100 = 58,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "Grand Theft Auto V",
                        Description = "Grand Theft Auto V for PC offers players the option to explore the award-winning world of Los Santos and Blaine County in resolutions of up to 4k and beyond, as well as the chance to experience the game running at 60 frames per second.",
                        Developer = "Rockstar North",
                        Publisher = "Rockstar Games",
                        ReleaseDate = new DateTime(2015, 4, 14),
                        ListPrice = 298,
                        Price = 98,
                        Price50 = 92,
                        Price100 = 85,
                        CategoryId = 3,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "PICO PARK",
                        Description = "PICO PARK is a cooperative local/online multiplay action puzzle game for 2-8 players.",
                        Developer = "TECOPARK",
                        Publisher = "TECOPARK",
                        ReleaseDate = new DateTime(2021, 5, 7),
                        ListPrice = 9.99,
                        Price = 4.99,
                        Price50 = 4.59,
                        Price100 = 4.29,
                        CategoryId = 2,
                        ImageUrl = ""
                    }
                );

            modelBuilder.Entity<Company>().HasData(
                    new Company
                    {
                        Id = 1,
                        Name = "Marlabs",
                        StreetAddress = "1 Corporate PI S",
                        State = "NJ",
                        PostalCode = "08854",
                        PhoneNumber = "732-694-1000",
                        City = "Piscataway"
                    },
                    new Company
                    {
                        Id = 2,
                        Name = "BeaconFire Solution",
                        StreetAddress = "50 Millstone Rd building 300 suite 120",
                        State = "NJ",
                        PostalCode = "08512",
                        PhoneNumber = "609-608-0477",
                        City = "East Windsor"
                    },
                    new Company
                    {
                        Id = 3,
                        Name = "Antra",
                        StreetAddress = "21000 Atlantic Blvd STE 300",
                        State = "VA",
                        PostalCode = "20166",
                        PhoneNumber = "703-994-4545",
                        City = "Sterling"
                    },
                    new Company
                    {
                        Id = 4,
                        Name = "Two Sigma",
                        StreetAddress = "100 6th Ave",
                        State = "NY",
                        PostalCode = "10013",
                        PhoneNumber = "212-625-5700",
                        City = "New York"
                    }
                );
        }
    }
}
