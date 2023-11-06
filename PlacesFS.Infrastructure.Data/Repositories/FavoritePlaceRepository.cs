using PlacesFS.Domain.Entities;
using PlacesFS.Domain.RepositoryContracts;
using PlacesFS.Infrastructure.Data.Context;


namespace PlacesFS.Infrastructure.Data.Repositories
{
	public class FavoritePlaceRepository : BaseRepository<FavoritePlace>, IFavoritePlaceRepository
	{
		public FavoritePlaceRepository(DataBaseContext context) : base(context)
		{
		}
	}
}
