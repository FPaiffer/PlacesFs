using PlacesFS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Application.Services.Contracts
{
	public interface IServiceBase<T, TDto> where T : class where TDto : BaseDto
	{
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
		Task<T> InsertAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task RemoveAsync(T entity);
		Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
		Task<TDto> ConvertToDto(T entity);
		Task<T> ConvertToEntity(TDto dto);
		Task<List<TDto>> ConvertToDto(List<T> entity);
		Task<List<T>> ConvertToEntity(List<TDto> dto);

	}
}
