﻿using Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.CatogeryDtos
{
	public class GetCategoryDto: BaseGetDto
	{
		public string Name { get; set; }
		public string ImageUrl { get; set; }
	}
}
