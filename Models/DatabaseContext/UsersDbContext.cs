using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;
using TestATOH1.Models.UserModels;
namespace TestATOH1.Models.DataBaseContext
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Initial
            modelBuilder.Entity<UserModel>().HasData(new UserModel { Guid = Guid.NewGuid(), Login = "Admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"), Name = "Max", Gender = 1, Birthday = DateTime.MaxValue, Admin = true, CreatedOn = DateTime.Now, CreatedBy = "admin", ModifiedOn = DateTime.Now, ModifiedBy = string.Empty, RevokedOn = DateTime.MaxValue, RevokedBy = string.Empty });
            modelBuilder.Entity<UserModel>().HasIndex(u => u.Login).IsUnique();
        }
    }
}
