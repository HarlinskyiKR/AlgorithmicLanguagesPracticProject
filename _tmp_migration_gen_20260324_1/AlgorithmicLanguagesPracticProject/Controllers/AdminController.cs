using AlgorithmicLanguagesPracticProject.Models.ViewModels;
using AlgorithmicLanguagesPracticProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmicLanguagesPracticProject.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IMediaService _mediaService;
    private readonly IUserService _userService;

    public AdminController(IMediaService mediaService, IUserService userService)
    {
        _mediaService = mediaService;
        _userService = userService;
    }

    public IActionResult Dashboard() => View();

    public IActionResult Media()
    {
        return View(_mediaService.GetAll());
    }

    public IActionResult Users()
    {
        return View(_userService.GetAllUsers());
    }

    public IActionResult Edit(int id)
    {
        var model = _mediaService.GetForEdit(id);
        if (model is null)
        {
            return NotFound();
        }

        ViewData["MediaId"] = id;
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, CreateMediaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MediaId"] = id;
            return View(model);
        }

        var updated = _mediaService.Update(id, model);
        if (!updated)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Media));
    }

    public IActionResult Delete(int id)
    {
        var media = _mediaService.GetForDelete(id);
        if (media is null)
        {
            return NotFound();
        }

        return View(media);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var deleted = _mediaService.Delete(id);
        if (!deleted)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Media));
    }

    public IActionResult Comments()
    {
        return View(_mediaService.GetComments());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteComment(int id)
    {
        _mediaService.DeleteComment(id);
        return RedirectToAction(nameof(Comments));
    }
}