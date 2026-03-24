using AlgorithmicLanguagesPracticProject.Models.ViewModels;

namespace AlgorithmicLanguagesPracticProject.Services.Interfaces;

public interface IMediaService
{
    List<MediaViewModel> GetAll();
    MediaDetailsViewModel? GetById(int id);
    void Create(CreateMediaViewModel model);
    void AddComment(int mediaId, int userId, string content);
    CreateMediaViewModel? GetForEdit(int id);
    bool Update(int id, CreateMediaViewModel model);
    MediaDeleteViewModel? GetForDelete(int id);
    bool Delete(int id);
    List<AdminCommentViewModel> GetComments();
    bool DeleteComment(int id);
}