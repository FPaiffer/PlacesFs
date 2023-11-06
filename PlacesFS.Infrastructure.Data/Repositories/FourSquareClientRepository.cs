using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlacesFS.Domain.RepositoryContracts;
using PlacesFS.Models.Dtos;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PlacesFS.Infrastructure.Data.Repositories
{
	public class FourSquareClientRepository : IFourSquareClientRepository
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;
		public FourSquareClientRepository(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
			_httpClient.BaseAddress = new Uri(configuration["FourSquareUrlBase"]);
			_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", configuration["FourSquareApiKey"]);
			_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
		}

        public async Task<List<PlaceImages>> GetPlaceImages(string fsq_id)
        {
            var result = new List<PlaceImages>();
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["sort"] = "NEWEST";
            queryParams["limit"] = "10";
            var queryString = queryParams.ToString();
            result = await _httpClient.GetFromJsonAsync<List<PlaceImages>>($"places/{fsq_id}/photos?{queryString}");
           
            return result;
        }

        public async Task<List<PlaceDto>> GetPlaces(string query, string longitude, string latitude)
		{
			var result = new List<PlaceDto>();
			var queryParams = HttpUtility.ParseQueryString(string.Empty);
			queryParams["query"] = query;
			queryParams["ll"] = $"{longitude},{latitude}";
			queryParams["fields"] = "fsq_id,name,location,link,geocodes,categories,rating";
			queryParams["sort"] = "DISTANCE";
			queryParams["limit"] = "20";
			var queryString = queryParams.ToString();
			var response = await _httpClient.GetFromJsonAsync<BaseResponse>($"places/search?{queryString}");
			result = JsonConvert.DeserializeObject<List<PlaceDto>>(response?.results.ToString());
			return result;
		}

        public async Task<List<PlaceTips>> GetPlaceTips(string fsq_id)
        {
            var result = new List<PlaceTips>();
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["sort"] = "NEWEST";
            queryParams["limit"] = "10";
            var queryString = queryParams.ToString();
            result = await _httpClient.GetFromJsonAsync<List<PlaceTips>>($"places/{fsq_id}/tips?{queryString}");

            return result;
        }
    }
}
