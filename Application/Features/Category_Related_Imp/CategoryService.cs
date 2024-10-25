using Application.Contract.IFeatures.ICategory;
using Application.Contract.IRepositories.ICommon;
using Application.Dtos.CategoryDtos;
using Application.Dtos.CatogeryDtos;
using Application.Features.Common;
using AutoMapper;
using Domin.Entities.Category_realted;
using Domin.Entities.Commin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category_Related_Imp
{
	public class CategoryService:BaseService<Category,GetCategoryDto,CreateCategoryDto,UpdateCategoryDto>,ICategoryService
	{
		public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}
	}
}
