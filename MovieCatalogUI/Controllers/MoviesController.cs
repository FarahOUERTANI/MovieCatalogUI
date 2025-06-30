using Microsoft.AspNetCore.Mvc;
using MovieCatalogUI.Services;

namespace MovieCatalogUI.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetMoviesAsync();
            return View(movies);
        }
    }
}