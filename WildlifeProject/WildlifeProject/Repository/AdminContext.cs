using Microsoft.EntityFrameworkCore;
using WildlifeProject.Model;

namespace WildlifeProject.Repository
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }
        public DbSet<AdminUser>? AdminUsers { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Category>? Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AdminUser>().HasData(
                new { UserKey = 1, UserName = "ArielJoseph111", Password = "ArielJoseph111" }
                );
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mammels" },
                new { CategoryId = 2, Name = "Birds" },
                new { CategoryId = 3, Name = "Reptilians" },
                new { CategoryId = 4, Name = "Amphibian" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new {AnimalId = 1, Name = "Honey Badger", PictureName = "~/Images/honey-bagder.jpg", Description = "~/Information/honey-badger.txt", CategoryId = 1, ConservationStatus = "Extinct in the wild" }
                );
            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, CommentText = "beautifull!", AnimalId = 1 }
                );

            modelBuilder.Entity<Animal>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Animals);
            modelBuilder.Entity<Animal>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.Animal);

            modelBuilder.Entity<Comment>()
            .Property(f => f.CommentId)
            .ValueGeneratedOnAdd();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
