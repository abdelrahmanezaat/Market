using Application.Contract.IFeatures;
using Application.Contract.IRepositories.ICommon;
using Application.Dtos.Common;
using Application.Exceptions;
using AutoMapper;
using Domin.Entities.Commin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Common
{
	public class BaseService<TEntity, TGetDto, TCreateDto, TUpdateDto> : IBaseService<TEntity, TGetDto, TCreateDto, TUpdateDto>
	   where TEntity : BaseEntity
	   where TGetDto : BaseGetDto
	   where TCreateDto : class
	   where TUpdateDto : class
	{
		protected readonly IUnitOfWork _unitOfWork;
		protected readonly IBaseRepository<TEntity> _repository;
		protected readonly IMapper _mapper;
		
		public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_repository = _unitOfWork.GetRepository<TEntity>();
			_mapper = mapper;
			
		}

		public virtual async Task<IEnumerable<TGetDto>> GetAllAsync()
		{
			var entities = await _repository.GetAllAsync(x => !x.IsDeleted);
			var entitiesDto = _mapper.Map<IEnumerable<TGetDto>>(entities);

			

			return entitiesDto;
		}

		public virtual async Task<TGetDto> GetByIdAsync(Guid id)
		{
			var entity = await GetDbEntityById(id);
			return _mapper.Map<TGetDto>(entity);
		}

		public virtual async Task<TEntity> CreateAsync(TCreateDto createDto)
		{
			// try
			//{
			var entity = _mapper.Map<TEntity>(createDto);
			await _repository.AddAsync(entity);
			await _unitOfWork.SaveChangesAsync();
			return entity;
			//}

			//catch (DbUpdateException)
			//{
			//  throw new SaveChangesFailedException();
			//}

			//catch (Exception ex)
			//{
			//  throw ex;
			//}
		}

		public virtual async Task<bool> CreateRangeAsync(IEnumerable<TCreateDto> createDtos)
		{
			try
			{
				var entities = _mapper.Map<IEnumerable<TEntity>>(createDtos).ToList();
				await _repository.AddRangeAsync(entities);
				await _unitOfWork.SaveChangesAsync();

				return entities.Any();
			}

			catch (DbUpdateException)
			{
				throw new SaveChangesFailedException();
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual async Task UpdateAsync(Guid id, TUpdateDto updateDto)
		{
			var entity = await GetDbEntityById(id);

			try
			{
				_mapper.Map(updateDto, entity);
				_repository.Update(entity);
				await _unitOfWork.SaveChangesAsync();
			}

			catch (DbUpdateException)
			{
				throw new SaveChangesFailedException();
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual async Task DeleteAsync(Guid id)
		{
			var entity = await GetDbEntityById(id);

			try
			{
				entity.IsDeleted = true;
				entity.DateDeleted = DateTimeOffset.Now;
				_repository.Update(entity);
				await _unitOfWork.SaveChangesAsync();
			}

			catch (DbUpdateException)
			{
				throw new SaveChangesFailedException();
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual async Task HardDeleteAsync(Guid id)
		{
			var entity = await GetDbEntityById(id);

			try
			{
				_repository.Delete(entity);
				await _unitOfWork.SaveChangesAsync();
			}

			catch (DbUpdateException)
			{
				throw new SaveChangesFailedException();
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual async Task<TEntity> GetDbEntityById(Guid id)
		{
			var entity = await _repository.GetByIdAsync(id) ?? throw new EntityNotFoundException($"Data");

			if (entity.IsDeleted) { throw new NoDataFoundException($"Something went wrong!"); }
			return entity;
		}

	}
}
