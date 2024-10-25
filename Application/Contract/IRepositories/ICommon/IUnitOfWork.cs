using Domin.Entities.Commin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IRepositories.ICommon
{
	public interface IUnitOfWork: IDisposable
	{
		IBaseRepository<T> GetRepository<T>() where T : BaseEntity;
		Task BeginTransactionAsync();
		void Rollback();
		Task SaveChangesAsync();
		Task CommitAsync();
	}
}
