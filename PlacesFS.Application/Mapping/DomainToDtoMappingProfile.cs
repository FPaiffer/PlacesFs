using AutoMapper;
using PlacesFS.Domain.Entities;
using PlacesFS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Application.Mapping
{
	public class DomainToDtoMappingProfile : Profile
	{
		public DomainToDtoMappingProfile()
		{
			CreateMap<EntityBase, BaseDto>();
			CreateMap<BaseDto, EntityBase>();

            CreateMap<FavoritePlace, FavoritePlaceDto>();
            CreateMap<FavoritePlaceDto, FavoritePlace>();
        }
	}
}
