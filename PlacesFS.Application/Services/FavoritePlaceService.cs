using AutoMapper;
using PlacesFS.Application.Services.Contracts;
using PlacesFS.Domain.Entities;
using PlacesFS.Domain.RepositoryContracts;
using PlacesFS.Models.Dtos;

namespace PlacesFS.Application.Services
{
	public class FavoritePlaceService : ServiceBase<FavoritePlace, FavoritePlaceDto>, IFavoritePlaceService
	{
		private readonly IMapper _mapper;
		private readonly IFavoritePlaceRepository _FavoritePlaceRepository;
		public FavoritePlaceService(IMapper mapper, IFavoritePlaceRepository FavoritePlaceRepository)
			: base(mapper, FavoritePlaceRepository)
		{
			_mapper = mapper;
			_FavoritePlaceRepository = FavoritePlaceRepository;
		}
	}
}
