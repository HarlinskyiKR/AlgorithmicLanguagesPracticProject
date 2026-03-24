using AlgorithmicLanguagesPracticProject.Models.Entities;
using AlgorithmicLanguagesPracticProject.Models.ViewModels;

namespace AlgorithmicLanguagesPracticProject.Services.Interfaces;

public interface IUserService
{
    User? Login(UserLoginViewModel model);
    (bool Success, string? Error) Register(UserRegisterViewModel model);
    Task LogoutAsync(HttpContext httpContext);
    UserProfileViewModel? GetProfile(int userId);
    List<AdminUserViewModel> GetAllUsers();
}
