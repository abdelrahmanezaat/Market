using Application.Contract.IRepositories.ICommon;
using Domin.Entities.Commin;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Common
{
	 public class UnitOfWork:IUnitOfWork 
	{
		private readonly MarketContext _context;
		private IDbContextTransaction _currentTransaction;
		public UnitOfWork(MarketContext context)
		{
			_context = context;
		}
		public IBaseRepository<T> GetRepository<T>() where T : BaseEntity
		{
			return new BaseRepository<T>(_context);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task BeginTransactionAsync()
		{
			if (_currentTransaction == null)
			{
				_currentTransaction = await _context.Database.BeginTransactionAsync();
			}
		}

		public void Rollback()
		{
			try
			{
				_currentTransaction?.Rollback();
			}
			finally
			{
				_currentTransaction = null;
			}
		}

		public async Task CommitAsync()
		{
			try
			{
				await _context.SaveChangesAsync();
				_currentTransaction?.Commit();
			}
			catch
			{
				Rollback();
				throw;
			}
			finally
			{
				_currentTransaction = null;
			}
		}
	}
}
