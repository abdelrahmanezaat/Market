using Domin.Entities.Commin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contract.IRepositories.ICommon;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Persistence.Context;

namespace Persistence.Repositories.Common
{
	public class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity
	{
		protected readonly MarketContext _context;
		private readonly DbSet<T> Entities;

		public BaseRepository(MarketContext context)
		{
			_context = context;
			Entities = _context.Set<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var query = Entities.AsQueryable().AsNoTracking();
			return await query.ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
		{
			var query = Entities.AsQueryable();
			return await query.Where(predicate).ToListAsync();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await Entities.FindAsync(id);
		}

		public async Task AddAsync(T entity)
		{
			await Entities.AddAsync(entity);
		}

		public async Task<T> AddAsyncWithReturn(T entity)
		{
			await Entities.AddAsync(entity);

			return entity;
		}

		public async Task AddRangeAsync(List<T> entity)
		{
			await Entities.AddRangeAsync(entity);
		}

		public void Update(T entity)
		{
			entity.DateUpdated = DateTimeOffset.Now;
			Entities.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
			Entities.Update(entity);
		}

		public void Delete(T entity)
		{
			entity.DateDeleted = DateTimeOffset.Now;
			_context.Entry(entity).State = EntityState.Deleted;
			Entities.Remove(entity);
		}

		public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			int? take = null,
			Expression<Func<T, object>>? orderBy = null, bool orderByDescending = false)
		{
			var query = Entities.AsQueryable().AsNoTracking();
			if (include != null) query = include(query);

			query = query.Where(predicate);

			if (orderBy != null)
			{
				query = orderByDescending
					? query.OrderByDescending(orderBy)
					: query.OrderBy(orderBy);
			}

			if (take.HasValue)
			{
				query = query.Take(take.Value);
			}

			return await query.ToListAsync();
		}

		public async Task<(int, List<T>)> FindWithPaginationAsync(Expression<Func<T, bool>> predicate,
			int pageNumber, int pageSize,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			Expression<Func<T, object>>? orderBy = null, bool orderByDescending = false)
		{
			int totalCount = 0;
			List<T> items = [];

			var query = Entities.AsQueryable().AsNoTracking();
			if (include != null) query = include(query);

			query = query.Where(predicate);

			if (orderBy != null)
			{
				query = orderByDescending
					? query.OrderByDescending(orderBy)
					: query.OrderBy(orderBy);
			}

			var result = await query
				.Select(e => new { TotalCount = query.Count(), Item = e })
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			if (result.Count != 0)
			{
				totalCount = result.First().TotalCount;
				items = result.Select(r => r.Item).ToList();
			}

			query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

			return (totalCount, items);
		}

		public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
		{
			var query = Entities.AsQueryable();
			if (include != null) query = include(query);
			return await query.FirstOrDefaultAsync(predicate);
		}

		public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
		{
			var query = Entities.AsQueryable();
			return await query.AnyAsync(predicate);
		}
	}
}

