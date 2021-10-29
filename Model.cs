using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs => Set<Blog>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Server=localhost;Database=test;Port=5432;User Id=postgres;Password=postgres;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                        .HasData(new Blog
                        {
                            Id = -1,
                            Url = "https://myblog.ru/intro",
                            Timestamp = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                        });
        }

        public class Blog
        {
            public long Id { get; set; }
            public string Url { get; set; } = string.Empty;
            public DateTime Timestamp { get; set; } = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            public DateTime WithoutDefault { get; set; }
        }
    }
}