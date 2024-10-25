using Application.Dtos.CategoryDtos;
using Application.Dtos.CatogeryDtos;
using Domin.Entities.Category_realted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IFeatures.ICategory
{
	public interface ICategoryService:IBaseService<Category,GetCategoryDto,CreateCategoryDto,UpdateCategoryDto>
	{
	}
}
