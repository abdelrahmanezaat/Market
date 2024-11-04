using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.CategoryDtos
{
	public class UpdateCategoryDto
	{
		public string Name { get; set; }
		public IFormFile Image { get; set; }
	}
}
