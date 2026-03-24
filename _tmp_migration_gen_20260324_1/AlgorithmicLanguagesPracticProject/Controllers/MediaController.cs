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

    public IActionResult Index()
    {
        var data = _mediaService.GetAll();
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
    public IActionResult Create() => View(new CreateMediaViewModel());

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateMediaViewModel model)
    {
        if (!ModelState.IsValid)
        {
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
