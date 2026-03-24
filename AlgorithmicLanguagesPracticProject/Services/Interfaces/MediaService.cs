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
            .AsNoTracking()
            .OrderByDescending(m => m.ReleaseYear)
            .Select(m => new MediaViewModel
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear
            }).ToList();
    }

    public MediaDetailsViewModel? GetById(int id)
    {
        var media = _context.Medias
            .AsNoTracking()
            .FirstOrDefault(m => m.Id == id);
        if (media is null)
        {
            return null;
        }

        var comments = _context.Comments
            .AsNoTracking()
            .Where(c => c.MediaId == id)
            .OrderByDescending(c => c.CreatedAt)
            .Select(c => new MediaCommentViewModel
            {
                Content = c.Content,
                CreatedAt = c.CreatedAt
            })
            .ToList();

        return new MediaDetailsViewModel
        {
            Id = media.Id,
            Title = media.Title,
            Description = media.Description,
            Comments = comments
        };
    }

    public void Create(CreateMediaViewModel model)
    {
        var media = new Media
        {
            Title = model.Title,
            Description = model.Description,
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
            ReleaseYear = media.ReleaseYear,
            Rating = media.Rating,
            StudioId = media.StudioId
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
            .OrderByDescending(c => c.CreatedAt)
            .Select(c => new AdminCommentViewModel
            {
                Id = c.Id,
                Content = c.Content,
                CreatedAt = c.CreatedAt,
                MediaId = c.MediaId,
                UserId = c.UserId
            })
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
}