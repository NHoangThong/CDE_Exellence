using CDE_Exellence.Model;
using Microsoft.EntityFrameworkCore;
namespace CDE_Exellence.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Thêm tài khoản mặc định
            var defaultUser = new User
            {
                Id = 1,
                Email = "admin@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"), // Mã hóa mật khẩu
                Role = "Admin"
            };

            modelBuilder.Entity<User>().HasData(defaultUser);
        }
    }
}
