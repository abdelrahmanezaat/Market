﻿using Application.Contract.IFeatures;
using Application.Contract.IFeatures.ICategory;
using Application.Features.Category_Related_Imp;
using Application.Features.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			// Common
			services.AddScoped(typeof(IBaseService<,,,>), typeof(BaseService<,,,>));


			//Category
			services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
		}
	}
}
