using AutoMapper;
using PlacesFS.Application.Services.Contracts;
using PlacesFS.Domain.Entities;
using PlacesFS.Domain.RepositoryContracts;
using PlacesFS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Application.Services
{
	public class ServiceBase<T, TDto> : IServiceBase<T, TDto> where T : class where TDto : BaseDto
	{
		private readonly IMapper _mapper;
		private readonly IBaseRepository<T> _repository;
     

        public ServiceBase(IMapper mapper, IBaseRepository<T> baseRepository)
		{
			_mapper = mapper;
			_repository = baseRepository;
		}
		public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
		{
			return await _repository.GetAllAsync(filter);
		}

		public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
		{
			return await _repository.GetSingleAsync(filter);
		}

		public async Task<T> InsertAsync(T entity)
		{
			return await _repository.InsertAsync(entity);
		}

		public virtual async Task<T> UpdateAsync(T entity)
		{
			return await _repository.UpdateAsync(entity);
		}

		public async Task RemoveAsync(T entity)
		{
			await _repository.RemoveAsync(entity);
		}

		public async Task<TDto> ConvertToDto(T entity)
		{
			return await Task.FromResult(_mapper.Map<TDto>(entity));
		}
		public async Task<T> ConvertToEntity(TDto dto)
		{
            return await Task.FromResult(_mapper.Map<T>(dto));
        }
		public async Task<List<TDto>> ConvertToDto(List<T> entities)
		{
			return await Task.FromResult(_mapper.Map<List<TDto>>(entities));
		}
		public async Task<List<T>> ConvertToEntity(List<TDto> dto)
		{
			return await Task.FromResult(_mapper.Map<List<T>>(dto));
		}

	}
}
