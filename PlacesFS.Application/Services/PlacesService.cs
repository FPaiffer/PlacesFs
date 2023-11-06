using PlacesFS.Application.Services.Contracts;
using PlacesFS.Domain.RepositoryContracts;
using PlacesFS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Application.Services
{
	public class PlacesService : IPlacesService
	{
		private readonly IFourSquareClientRepository _placesRepository;
		public PlacesService(IFourSquareClientRepository placesRepository)
		{
			_placesRepository = placesRepository;
		}

        public async Task<List<string>> GetPlaceImages(string fsq_id)
        {
            var response = new List<string>();
            try
            {
                List<PlaceImages> result = await _placesRepository.GetPlaceImages(fsq_id);
               foreach (PlaceImages image in result) 
				{
					var src = $"{image.prefix}200x200{image.suffix}";
                    response.Add(src);
                }
            }
            catch (Exception e)
            {
                response=new List<string>();
            }
            return response;
        }

        public async Task<ResponseHelper> GetPlaces(string query, string longitude, string latitude)
		{
			var response = new ResponseHelper();
			try
			{
				List<PlaceDto> result = await _placesRepository.GetPlaces(query, longitude, latitude);
				if (result != null)
				{
					response.Success = true;
					response.Data = result;
					response.Message = "Places retrieved successfully";
				}
				else
				{
					response.Success = true;
					response.Data = null;
					response.Message = "No Places For this search";
				}
			}
			catch (Exception e)
			{
				response.Message = $"Exception : {e.Message}";
			}
			return response;
		}

        public async Task<List<string>> GetPlaceTips(string fsq_id)
        {
            var response = new List<string>();
            try
            {
                List<PlaceTips> result = await _placesRepository.GetPlaceTips(fsq_id);
                foreach (PlaceTips tip in result)
                {
                    response.Add(tip.text);
                }
            }
            catch (Exception e)
            {
                response = new List<string>();
            }
            return response;
        }
    }
}
