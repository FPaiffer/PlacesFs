using PlacesFS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Domain.RepositoryContracts
{
	public interface IFourSquareClientRepository
	{
        Task<List<PlaceImages>> GetPlaceImages(string fsq_id);
        Task<List<PlaceDto>> GetPlaces(string query, string longitude, string latitude);
        Task<List<PlaceTips>> GetPlaceTips(string fsq_id);
    }
}
