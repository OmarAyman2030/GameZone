using GameZone.Models;

namespace GameZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }

      public DbSet<Game> Games { get; set; }
      public DbSet<Category> Categories { get; set; }
      public DbSet<Device> Devices { get; set; }
      public DbSet<GameDevice> GameDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDevice>()
                .HasKey(e => new { e.DeviceID , e.GameID});

            modelBuilder.Entity<Category>().
                HasData(new Category[]
               { 
                
                   new Category { ID = 1, Name = "Sports" } ,
                   new Category { ID = 2, Name = "Action" } ,
                   new Category { ID = 3, Name = "Adventure" },
                   new Category { ID = 4, Name = "Racing" },
                   new Category { ID = 5, Name = "Film" },
                   new Category { ID = 6, Name = "Fighting" },
                });

            modelBuilder.Entity<Device>().
               HasData(new Device[]
              {

                   new Device { ID = 1, Name = "PlayStation" , Icon = "bi - bi-playstaion" } ,
                   new Device { ID = 2, Name = "Xbox" , Icon = "bi - bi-Xbox" } ,
                   new Device { ID = 3, Name = "PC-Games"  , Icon = "bi - bi-PC-Games"},
                   new Device { ID = 4, Name = "Arkade"  , Icon = "bi - bi-Arkade"},
                   new Device { ID = 5, Name = "VR_MetA"  , Icon = "bi - bi-VR_MetA"},
                   
               });

            base.OnModelCreating(modelBuilder);
        }


    }
}
