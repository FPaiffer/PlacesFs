using PlacesFS.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Infrastructure.Data.Repositories
{
	public class BaseRepository<T> where T : class
	{
		protected readonly DataBaseContext Context;
		public BaseRepository(DataBaseContext context)
		{
			Context = context;
		}
		public virtual async Task<T> InsertAsync(T entity)
		{
			await Context.Set<T>().AddAsync(entity);
			await Context.SaveChangesAsync();
			return entity;
		}
		public virtual async Task<T> UpdateAsync(T entity)
		{
			Context.Entry(entity).State = EntityState.Modified;
			await Context.SaveChangesAsync();
			return entity;
		}
		public virtual async Task RemoveAsync(T entidade)
		{
			Context.Set<T>().Remove(entidade);
			await Context.SaveChangesAsync();
		}
		public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
		{
			var query = Context.Set<T>().AsQueryable();
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.ToListAsync();
		}
		public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter = null)
		{
			var query = Context.Set<T>().AsQueryable();
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.SingleOrDefaultAsync();
		}
	}
}
