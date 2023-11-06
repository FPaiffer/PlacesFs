using PlacesFS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Application.Services.Contracts
{
	public interface IPlacesService
	{
        Task<List<string>> GetPlaceImages(string fsq_id);
        Task<ResponseHelper> GetPlaces(string query, string longitude ,string latitude);
        Task<List<string>> GetPlaceTips(string fsq_id);
    }
}
