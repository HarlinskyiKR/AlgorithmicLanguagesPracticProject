using AlgorithmicLanguagesPracticProject.Data;
using AlgorithmicLanguagesPracticProject.Models.Entities;
using AlgorithmicLanguagesPracticProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AlgorithmicLanguagesPracticProject.Services.Interfaces;

public class MediaService : IMediaService
{
    private readonly AppDbContext _context;

    public MediaService(AppDbContext context)
    {
        _context = context;
    }

    public List<MediaViewModel> GetAll()
    {
        return _context.Medias
            .Include(m => m.Genre)
            .AsNoTracking()
            .OrderByDescending(m => m.ReleaseYear)
            .Select(m => new MediaViewModel
            {
                Id = m.Id,
                Title = m.Title,
                GenreName = m.Genre != null ? m.Genre.Name : string.Empty,
                Country = m.Country,
                PosterUrl = m.PosterUrl,
                ReleaseYear = m.ReleaseYear,
                CommentsCount = m.Comments.Count,
                Rating = m.Rating,
                Description = m.Description
            }).ToList();
    }

    public List<MediaViewModel> GetAllByGenre(int genreId)
    {
        return _context.Medias
            .Include(m => m.Genre)
            .AsNoTracking()
            .Where(m => m.GenreId == genreId)
            .OrderByDescending(m => m.ReleaseYear)
            .Select(m => new MediaViewModel
            {
                Id = m.Id,
                Title = m.Title,
                GenreName = m.Genre != null ? m.Genre.Name : string.Empty,
                Country = m.Country,
                PosterUrl = m.PosterUrl,
                ReleaseYear = m.ReleaseYear,
                CommentsCount = m.Comments.Count,
                Rating = m.Rating,
                Description = m.Description
            }).ToList();
    }

    public List<Genre> GetAllGenres()
    {
        return _context.Genres
            .AsNoTracking()
            .OrderBy(g => g.Name)
            .ToList();
    }

    public Genre? GetGenreById(int id)
    {
        return _context.Genres.FirstOrDefault(g => g.Id == id);
    }

    public void AddGenre(string name)
    {
        var genre = new Genre { Name = name };
        _context.Genres.Add(genre);
        _context.SaveChanges();
    }

    public void UpdateGenre(int id, string name)
    {
        var genre = _context.Genres.FirstOrDefault(g => g.Id == id);
        if (genre != null)
        {
            genre.Name = name;
            _context.SaveChanges();
        }
    }

    public void DeleteGenre(int id)
    {
        var genre = _context.Genres.Include(g => g.Media).FirstOrDefault(g => g.Id == id);
        if (genre != null && (genre.Media == null || genre.Media.Count == 0))
        {
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }

    public MediaDetailsViewModel? GetById(int id)
    {
        var media = _context.Medias
            .Include(m => m.Genre)
            .AsNoTracking()
            .FirstOrDefault(m => m.Id == id);
        if (media is null)
        {
            return null;
        }

        var comments = _context.Comments
            .AsNoTracking()
            .Where(c => c.MediaId == id)
            .Join(
                _context.Users,
                c => c.UserId,
                u => u.Id,
                (c, u) => new MediaCommentViewModel
                {
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    Username = u.Username
                }
            )
            .OrderByDescending(c => c.CreatedAt)
            .ToList();

        return new MediaDetailsViewModel
        {
            Id = media.Id,
            Title = media.Title,
            Description = media.Description,
            GenreName = media.Genre != null ? media.Genre.Name : string.Empty,
            Country = media.Country,
            Directors = media.Directors,
            Actors = media.Actors,
            PlayerIframeUrl = media.PlayerIframeUrl,
            PosterUrl = media.PosterUrl,
            ReleaseYear = media.ReleaseYear,
            Rating = media.Rating,
            Comments = comments
        };
    }

    public void Create(CreateMediaViewModel model)
    {
        var media = new Media
        {
            Title = model.Title,
            Description = model.Description,
            GenreId = model.GenreId,
            Country = model.Country,
            Directors = model.Directors,
            Actors = model.Actors,
            PlayerIframeUrl = model.PlayerIframeUrl,
            PosterUrl = model.PosterUrl,
            ReleaseYear = model.ReleaseYear,
            Rating = model.Rating,
            StudioId = model.StudioId
        };
        _context.Medias.Add(media);
        _context.SaveChanges();
    }

    public void AddComment(int mediaId, int userId, string content)
    {
        var mediaExists = _context.Medias.Any(m => m.Id == mediaId);
        if (!mediaExists)
        {
            return;
        }

        var comment = new Comment
        {
            Content = content.Trim(),
            CreatedAt = DateTime.UtcNow,
            MediaId = mediaId,
            UserId = userId
        };

        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    public CreateMediaViewModel? GetForEdit(int id)
    {
        var media = _context.Medias.AsNoTracking().FirstOrDefault(m => m.Id == id);
        if (media is null)
        {
            return null;
        }

        return new CreateMediaViewModel
        {
            Title = media.Title,
            Description = media.Description,
            GenreId = media.GenreId,
            Country = media.Country,
            Directors = media.Directors,
            Actors = media.Actors,
            PlayerIframeUrl = media.PlayerIframeUrl,
            PosterUrl = media.PosterUrl,
            ReleaseYear = media.ReleaseYear,
            Rating = media.Rating,
            StudioId = media.StudioId,
            Genres = _context.Genres.AsNoTracking().OrderBy(g => g.Name).ToList()
        };
    }

    public bool Update(int id, CreateMediaViewModel model)
    {
        var media = _context.Medias.FirstOrDefault(m => m.Id == id);
        if (media is null)
        {
            return false;
        }

        media.Title = model.Title;
        media.Description = model.Description;
        media.GenreId = model.GenreId;
        media.Country = model.Country;
        media.Directors = model.Directors;
        media.Actors = model.Actors;
        media.PlayerIframeUrl = model.PlayerIframeUrl;
        media.PosterUrl = model.PosterUrl;
        media.ReleaseYear = model.ReleaseYear;
        media.Rating = model.Rating;
        media.StudioId = model.StudioId;

        _context.SaveChanges();
        return true;
    }

    public MediaDeleteViewModel? GetForDelete(int id)
    {
        return _context.Medias
            .AsNoTracking()
            .Where(m => m.Id == id)
            .Select(m => new MediaDeleteViewModel
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                Rating = m.Rating
            })
            .FirstOrDefault();
    }

    public bool Delete(int id)
    {
        var media = _context.Medias.FirstOrDefault(m => m.Id == id);
        if (media is null)
        {
            return false;
        }

        _context.Medias.Remove(media);
        _context.SaveChanges();
        return true;
    }

    public List<AdminCommentViewModel> GetComments()
    {
        return _context.Comments
            .AsNoTracking()
            .Join(
                _context.Users,
                c => c.UserId,
                u => u.Id,
                (c, u) => new AdminCommentViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    MediaId = c.MediaId,
                    UserId = c.UserId,
                    Username = u.Username
                }
            )
            .OrderByDescending(c => c.CreatedAt)
            .ToList();
    }

    public bool DeleteComment(int id)
    {
        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
        if (comment is null)
        {
            return false;
        }

        _context.Comments.Remove(comment);
        _context.SaveChanges();
        return true;
    }

    public List<AdminUserViewModel> GetAllUsers()
    {
        return _context.Users.AsNoTracking()
            .OrderBy(u => u.Id)
            .Select(u => new AdminUserViewModel
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role
            })
            .ToList();
    }
}