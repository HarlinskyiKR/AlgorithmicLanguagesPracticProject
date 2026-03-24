using System.Security.Claims;
using AlgorithmicLanguagesPracticProject.Models.ViewModels;
using AlgorithmicLanguagesPracticProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmicLanguagesPracticProject.Controllers;

public class MediaController : Controller
{
    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    public IActionResult Index(int? genreId)
    {
        var data = genreId.HasValue ? _mediaService.GetAllByGenre(genreId.Value) : _mediaService.GetAll();
        var genres = _mediaService.GetAllGenres();
        ViewBag.Genres = genres;
        if (genreId.HasValue)
        {
            var selectedGenre = genres.FirstOrDefault(g => g.Id == genreId.Value);
            ViewBag.SelectedGenre = selectedGenre;
        }
        else
        {
            ViewBag.SelectedGenre = null;
        }
        return View(data);
    }

    public IActionResult Details(int id)
    {
        var model = _mediaService.GetById(id);
        if (model is null)
        {
            return NotFound();
        }

        return View(model);
    }

    [Authorize]
    public IActionResult Create()
    {
        var model = new CreateMediaViewModel
        {
            Genres = _mediaService.GetAllGenres()
        };
        return View(model);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateMediaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Genres = _mediaService.GetAllGenres();
            return View(model);
        }

        _mediaService.Create(model);
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddComment(int mediaId, string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return RedirectToAction(nameof(Details), new { id = mediaId });
        }

        var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var parsedId)
            ? parsedId
            : 0;

        _mediaService.AddComment(mediaId, userId, content);
        return RedirectToAction(nameof(Details), new { id = mediaId });
    }
}
