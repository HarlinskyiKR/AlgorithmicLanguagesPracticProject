using AlgorithmicLanguagesPracticProject.Models.ViewModels;
using AlgorithmicLanguagesPracticProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmicLanguagesPracticProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMediaService _mediaService;

        public AdminController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet]
        public IActionResult EditGenre(int id)
        {
            var genre = _mediaService.GetGenreById(id);
            if (genre == null) return NotFound();
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditGenre(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError("", "Назва жанру не може бути порожньою");
                var genre = _mediaService.GetGenreById(id);
                return View(genre);
            }
            _mediaService.UpdateGenre(id, name);
            return RedirectToAction(nameof(Genres));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGenre(int id)
        {
            _mediaService.DeleteGenre(id);
            return RedirectToAction(nameof(Genres));
        }

        [HttpGet]
        public IActionResult Genres()
        {
            var genres = _mediaService.GetAllGenres();
            return View(genres);
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGenre(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError("", "Назва жанру не може бути порожньою");
                return View();
            }
            _mediaService.AddGenre(name);
            return RedirectToAction(nameof(Genres));
        }

        [HttpGet]
        public IActionResult Comments()
        {
            var comments = _mediaService.GetComments();
            return View(comments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComment(int id)
        {
            _mediaService.DeleteComment(id);
            return RedirectToAction(nameof(Comments));
        }

        [HttpGet]
        public IActionResult Media()
        {
            var medias = _mediaService.GetAll();
            return View(medias);
        }

        [HttpGet]
        public IActionResult DeleteMedia(int id)
        {
            var media = _mediaService.GetForDelete(id);
            if (media == null) return NotFound();
            return View(media);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMediaConfirmed(int id)
        {
            _mediaService.Delete(id);
            return RedirectToAction(nameof(Media));
        }

        [HttpGet]
        public IActionResult EditMedia(int id)
        {
            var media = _mediaService.GetForEdit(id);
            if (media == null) return NotFound();
            return View(media);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMedia(int id, CreateMediaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _mediaService.GetAllGenres();
                return View(model);
            }
            var success = _mediaService.Update(id, model);
            if (!success) return NotFound();
            return RedirectToAction(nameof(Media));
        }

        [HttpGet]
        public IActionResult CreateMedia()
        {
            return View(new CreateMediaViewModel { Genres = _mediaService.GetAllGenres() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMedia(CreateMediaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _mediaService.GetAllGenres();
                return View(model);
            }
            _mediaService.Create(model);
            return RedirectToAction(nameof(Media));
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _mediaService.GetAllUsers();
            return View(users);
        }
    }
}