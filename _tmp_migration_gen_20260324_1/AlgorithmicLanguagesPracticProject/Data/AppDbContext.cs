using AlgorithmicLanguagesPracticProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlgorithmicLanguagesPracticProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Media> Medias => Set<Media>();
    public DbSet<Studio> Studios => Set<Studio>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Studio>()
            .HasMany(s => s.Medias)
            .WithOne(m => m.Studio)
            .HasForeignKey(m => m.StudioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Media>()
            .HasMany(m => m.Comments)
            .WithOne()
            .HasForeignKey(c => c.MediaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Studio>().HasData(
            new Studio { Id = 1, Name = "Universal", Country = "USA" },
            new Studio { Id = 2, Name = "Warner Bros", Country = "USA" },
            new Studio { Id = 3, Name = "Pixar", Country = "USA" }
        );

        modelBuilder.Entity<Media>().HasData(
            new Media
            {
                Id = 1,
                Title = "Interstellar",
                Description = "Фантастичний фільм про дослідження космосу.",
                ReleaseYear = 2014,
                Rating = 8.7,
                StudioId = 1
            },
            new Media
            {
                Id = 2,
                Title = "Inception",
                Description = "Науково-фантастичний трилер про сни.",
                ReleaseYear = 2010,
                Rating = 8.8,
                StudioId = 2
            },
            new Media
            {
                Id = 3,
                Title = "Dune",
                Description = "Епічна фантастична історія про боротьбу за Арракіс.",
                ReleaseYear = 2021,
                Rating = 8.0,
                StudioId = 1
            },
            new Media
            {
                Id = 4,
                Title = "Soul",
                Description = "Анімаційний фільм про сенс життя та музику.",
                ReleaseYear = 2020,
                Rating = 8.1,
                StudioId = 3
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@local",
                PasswordHash = "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=",
                Role = "Admin"
            },
            new User
            {
                Id = 2,
                Username = "user1",
                Email = "user1@local",
                PasswordHash = "5gbjiw2MGbJM8O44CBgxYup81j/3kS27IrXoAyhrREY=",
                Role = "User"
            },
            new User
            {
                Id = 3,
                Username = "user2",
                Email = "user2@local",
                PasswordHash = "k36NX7tIvUlJU2zWW401xCa4DS+DDFwwjizexCKuIkQ=",
                Role = "User"
            }
        );

        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                Id = 1,
                Content = "Один з найкращих фільмів!",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                MediaId = 1,
                UserId = 1
            },
            new Comment
            {
                Id = 2,
                Content = "Сюжет тримає в напрузі до кінця.",
                CreatedAt = new DateTime(2026, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                MediaId = 2,
                UserId = 2
            },
            new Comment
            {
                Id = 3,
                Content = "Візуал і музика просто чудові.",
                CreatedAt = new DateTime(2026, 1, 3, 0, 0, 0, DateTimeKind.Utc),
                MediaId = 3,
                UserId = 3
            },
            new Comment
            {
                Id = 4,
                Content = "Дуже теплий і мотиваційний мультфільм.",
                CreatedAt = new DateTime(2026, 1, 4, 0, 0, 0, DateTimeKind.Utc),
                MediaId = 4,
                UserId = 2
            }
        );
    }
}
