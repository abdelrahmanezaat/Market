using Domin.Entities.Commin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IFeatures
{
	public interface IBaseService<TEntity,TGetDto,TCreateDto,TUpdateDto>
		where TEntity : BaseEntity
		where TGetDto : class
		where TCreateDto : class
		where TUpdateDto : class
	{
		Task<IEnumerable<TGetDto>> GetAllAsync();
		Task<TGetDto> GetByIdAsync(Guid id);
		Task<TEntity> CreateAsync(TCreateDto createDto);
		Task<bool> CreateRangeAsync(IEnumerable<TCreateDto> createDtos);
		Task UpdateAsync(Guid id, TUpdateDto updateDto);
		Task DeleteAsync(Guid id);
		Task HardDeleteAsync(Guid id);
		Task<TEntity> GetDbEntityById(Guid id);
	}
}
