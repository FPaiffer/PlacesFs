using PlacesFS.Application.Services.Contracts;
using PlacesFS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PlacesFS.Models.Dtos;
using Newtonsoft.Json;
using Azure.Core;
using AutoMapper;

namespace PlacesFS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlacesService _placeService;
        private readonly IFavoritePlaceService _favoritePlaceService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IPlacesService placeService, IFavoritePlaceService favoritePlaceService, IMapper mapper)
        {
            _logger = logger;
            _placeService = placeService;
            _favoritePlaceService= favoritePlaceService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            //var places= await _placeService.GetPlaces("sportbar", "21.17429", "-86.84656");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetPlaces(GetPlacesRequest request)
        {
            return Ok(await _placeService.GetPlaces(request.query, request.latitude.ToString(), request.longitude.ToString()));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> DetailOfPlace(PlaceDto place)
        {
            FavoritePlaceDto model = new FavoritePlaceDto();
            model.Name = place.name;
            model.Address = place.location.formatted_address;
            var CategorysName = "";
            if (place.categories != null && place.categories.FirstOrDefault() != null)
            {
                CategorysName = string.Join(",", place.categories.Select(a => a.short_name).ToList());
            }
            model.rating= place.rating;
            model.CategorysName = CategorysName;
            model.fsq_id = place.fsq_id;
            model.TipsSeparatedByPipes = string.Join("|", await _placeService.GetPlaceTips(place.fsq_id));
            model.ImagesSeparatedByPipes = string.Join("|", await _placeService.GetPlaceImages(place.fsq_id));
            return PartialView("_DetailOfPlacePartialView", model);
        }
         public async Task<IActionResult> SaveFavorites(FavoritePlaceDto place) 
        {

            var exist = await _favoritePlaceService.GetSingleAsync(a => a.fsq_id == place.fsq_id);
            if (exist is null) 
            {
                var entity = await _favoritePlaceService.ConvertToEntity(place);
                var result = await _favoritePlaceService.InsertAsync(entity);
            }
           
           return RedirectToAction("Index", "Favorite", null);
        }


    }
}
