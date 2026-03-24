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
    public DbSet<Genre> Genres => Set<Genre>();

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
                GenreId = 4, // Фантастика
                Country = "USA",
                Directors = "Christopher Nolan",
                Actors = "Matthew McConaughey, Anne Hathaway, Jessica Chastain",
                PlayerIframeUrl = "https://www.youtube.com/embed/zSWdZVtXT7E",
                PosterUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg",
                ReleaseYear = 2014,
                Rating = 8.7,
                StudioId = 1
            },
            new Media
            {
                Id = 2,
                Title = "Inception",
                Description = "Науково-фантастичний трилер про сни.",
                GenreId = 4, // Фантастика
                Country = "USA",
                Directors = "Christopher Nolan",
                Actors = "Leonardo DiCaprio, Joseph Gordon-Levitt, Elliot Page",
                PlayerIframeUrl = "https://www.youtube.com/embed/YoHD9XEInc0",
                PosterUrl = "https://image.tmdb.org/t/p/w500/8IB2e4r4oVhHnANbnm7O3Tj6tF8.jpg",
                ReleaseYear = 2010,
                Rating = 8.8,
                StudioId = 2
            },
            new Media
            {
                Id = 3,
                Title = "Dune",
                Description = "Епічна фантастична історія про боротьбу за Арракіс.",
                GenreId = 4, // Фантастика
                Country = "USA",
                Directors = "Denis Villeneuve",
                Actors = "Timothée Chalamet, Rebecca Ferguson, Oscar Isaac",
                PlayerIframeUrl = "https://www.youtube.com/embed/8g18jFHCLXk",
                PosterUrl = "https://image.tmdb.org/t/p/w500/d5NXSklXo0qyIYkgV94XAgMIckC.jpg",
                ReleaseYear = 2021,
                Rating = 8.0,
                StudioId = 1
            },
            new Media
            {
                Id = 4,
                Title = "Soul",
                Description = "Анімаційний фільм про сенс життя та музику.",
                GenreId = 1, // Драма
                Country = "USA",
                Directors = "Pete Docter, Kemp Powers",
                Actors = "Jamie Foxx, Tina Fey, Graham Norton",
                PlayerIframeUrl = "https://www.youtube.com/embed/xOsLIiBStEs",
                PosterUrl = "https://image.tmdb.org/t/p/w500/hm58Jw4Lw8OIeECIq5qyPYhAeRJ.jpg",
                ReleaseYear = 2020,
                Rating = 8.1,
                StudioId = 3
            },
            new Media
            {
                Id = 5,
                Title = "The Godfather",
                Description = "Класичний кримінальний фільм про мафію.",
                GenreId = 1, // Драма
                Country = "USA",
                Directors = "Francis Ford Coppola",
                Actors = "Marlon Brando, Al Pacino, James Caan",
                PlayerIframeUrl = "https://www.youtube.com/embed/sY1S34973zA",
                PosterUrl = "https://image.tmdb.org/t/p/w500/3bhkrj58Vtu7enYsRolD1fZdja1.jpg",
                ReleaseYear = 1972,
                Rating = 9.2,
                StudioId = 2
            },
            new Media
            {
                Id = 6,
                Title = "The Dark Knight",
                Description = "Бетмен проти Джокера у темному трилері.",
                GenreId = 2, // Бойовик (або створіть окремий жанр Action)
                Country = "USA",
                Directors = "Christopher Nolan",
                Actors = "Christian Bale, Heath Ledger, Aaron Eckhart",
                PlayerIframeUrl = "https://www.youtube.com/embed/EXeTwQWrcwY",
                PosterUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg",
                ReleaseYear = 2008,
                Rating = 9.0,
                StudioId = 1
            },
            new Media
            {
                Id = 7,
                Title = "The Matrix",
                Description = "Фантастичний кінематографований серіал про матрицю.",
                GenreId = 4, // Фантастика
                Country = "USA",
                Directors = "Lana Wachowski, Lilly Wachowski",
                Actors = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss",
                PlayerIframeUrl = "https://www.youtube.com/embed/vKQi3bBA1y8",
                PosterUrl = "https://m.media-amazon.com/images/M/MV5BODQzMTVkMTUtZTJkYS00NmZiLWFmNDgtYmEzOWNhNmJkZGJhXkEyXkFqcGc@._V1_.jpg",
                ReleaseYear = 1999,
                Rating = 8.7,
                StudioId = 2
            },
            new Media
            {
                Id = 8,
                Title = "Pulp Fiction",
                Description = "Культовий кримінальний фільм з нелінійним сюжетом.",
                GenreId = 1, // Драма
                Country = "USA",
                Directors = "Quentin Tarantino",
                Actors = "John Travolta, Uma Thurman, Samuel L. Jackson",
                PlayerIframeUrl = "https://www.youtube.com/embed/s7EdQ4FqbhY",
                PosterUrl = "https://image.tmdb.org/t/p/w500/d5iIlFn5s0ImszYzBPb8JPIfbXD.jpg",
                ReleaseYear = 1994,
                Rating = 8.9,
                StudioId = 1
            },
            new Media
            {
                Id = 9,
                Title = "The Shawshank Redemption",
                Description = "Драма про надію та дружбу в тюрмі.",
                GenreId = 1, // Драма
                Country = "USA",
                Directors = "Frank Darabont",
                Actors = "Tim Robbins, Morgan Freeman, Bob Gunton",
                PlayerIframeUrl = "https://www.youtube.com/embed/6hB3S9bIaco",
                PosterUrl = "https://image.tmdb.org/t/p/w500/q6y0Go1tsGEsmtFryDOJo3dEmqu.jpg",
                ReleaseYear = 1994,
                Rating = 9.3,
                StudioId = 2
            },
            new Media
            {
                Id = 10,
                Title = "Forrest Gump",
                Description = "Трогательная история о жизни Форреста Гампа.",
                GenreId = 1, // Драма
                Country = "USA",
                Directors = "Robert Zemeckis",
                Actors = "Tom Hanks, Robin Wright, Gary Sinise",
                PlayerIframeUrl = "https://www.youtube.com/embed/bLvqoHBptjg",
                PosterUrl = "https://image.tmdb.org/t/p/w500/saHP97rTPS5eLmrLQEcANmKrsFl.jpg",
                ReleaseYear = 1994,
                Rating = 8.8,
                StudioId = 1
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
        // Media-Genre: one-to-many
        modelBuilder.Entity<Media>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Media)
            .HasForeignKey(m => m.GenreId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed genres (приклад)
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Драма" },
            new Genre { Id = 2, Name = "Комедія" },
            new Genre { Id = 3, Name = "Бойовик" },
            new Genre { Id = 4, Name = "Фантастика" }
        );
    }
}
