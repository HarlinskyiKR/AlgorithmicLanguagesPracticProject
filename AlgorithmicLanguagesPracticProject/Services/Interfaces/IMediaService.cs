using AlgorithmicLanguagesPracticProject.Models.ViewModels;
using AlgorithmicLanguagesPracticProject.Models.Entities;

namespace AlgorithmicLanguagesPracticProject.Services.Interfaces;

public interface IMediaService
{
    List<AdminUserViewModel> GetAllUsers();
    List<MediaViewModel> GetAll();
    List<MediaViewModel> GetAllByGenre(int genreId);
    MediaDetailsViewModel? GetById(int id);
    void Create(CreateMediaViewModel model);
    void AddComment(int mediaId, int userId, string content);
    CreateMediaViewModel? GetForEdit(int id);
    bool Update(int id, CreateMediaViewModel model);
    MediaDeleteViewModel? GetForDelete(int id);
    bool Delete(int id);
    List<AdminCommentViewModel> GetComments();
    bool DeleteComment(int id);

    List<Genre> GetAllGenres();

    Genre? GetGenreById(int id);
    void AddGenre(string name);
    void UpdateGenre(int id, string name);
    void DeleteGenre(int id);
}