using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Domain.RepositoryContracts
{
	public interface IBaseRepository<T> where T : class
	{		
		Task<T> InsertAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task RemoveAsync(T entity);
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
		Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
	}
}
