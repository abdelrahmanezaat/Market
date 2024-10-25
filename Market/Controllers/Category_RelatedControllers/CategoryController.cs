using Application.Contract.IFeatures.ICategory;
using Application.Dtos.CategoryDtos;
using Application.Dtos.CatogeryDtos;
using Domin.Entities.Category_realted;
using Market.Controllers.Common;

namespace Market.Controllers.Category_RelatedControllers
{
	public class CategoryController:BaseController<Category, GetCategoryDto, CreateCategoryDto, UpdateCategoryDto>
	{
		private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService): base(categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
