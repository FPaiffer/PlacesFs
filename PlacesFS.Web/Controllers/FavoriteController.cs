using Microsoft.AspNetCore.Mvc;
using PlacesFS.Application.Services.Contracts;

namespace PlacesFS.Web.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoritePlaceService _favoritePlaceService;
        public FavoriteController(IFavoritePlaceService favoritePlaceService)
        {
            _favoritePlaceService=favoritePlaceService;
        }

        public async Task<IActionResult> Index()
        {
            var entities = await _favoritePlaceService.GetAllAsync();
            return View(await _favoritePlaceService.ConvertToDto(entities));
        }
    }
}
