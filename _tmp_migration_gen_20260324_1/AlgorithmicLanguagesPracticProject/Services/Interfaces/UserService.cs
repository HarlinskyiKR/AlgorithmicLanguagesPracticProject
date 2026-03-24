using System.Security.Cryptography;
using System.Text;
using AlgorithmicLanguagesPracticProject.Data;
using AlgorithmicLanguagesPracticProject.Models.Entities;
using AlgorithmicLanguagesPracticProject.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace AlgorithmicLanguagesPracticProject.Services.Interfaces;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public User? Login(UserLoginViewModel model)
    {
        var passwordHash = HashPassword(model.Password);
        return _context.Users.FirstOrDefault(u =>
            u.Email == model.Email && u.PasswordHash == passwordHash);
    }

    public (bool Success, string? Error) Register(UserRegisterViewModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            return (false, "Паролі не співпадають.");
        }

        var emailExists = _context.Users.Any(u => u.Email == model.Email);
        if (emailExists)
        {
            return (false, "Користувач з таким email вже існує.");
        }

        var usernameExists = _context.Users.Any(u => u.Username == model.Username);
        if (usernameExists)
        {
            return (false, "Користувач з таким логіном вже існує.");
        }

        var user = new User
        {
            Username = model.Username,
            Email = model.Email,
            PasswordHash = HashPassword(model.Password),
            Role = "User"
        };

        _context.Users.Add(user);
        _context.SaveChanges();
        return (true, null);
    }

    public async Task LogoutAsync(HttpContext httpContext)
    {
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public UserProfileViewModel? GetProfile(int userId)
    {
        return _context.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .Select(u => new UserProfileViewModel
            {
                Username = u.Username,
                Email = u.Email,
                Role = u.Role
            })
            .FirstOrDefault();
    }

    public List<AdminUserViewModel> GetAllUsers()
    {
        return _context.Users
            .AsNoTracking()
            .OrderBy(u => u.Username)
            .Select(u => new AdminUserViewModel
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role
            })
            .ToList();
    }

    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}
