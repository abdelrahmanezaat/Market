using Application.Contract.IInfrastructure;
using Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extension
{
	public static class ServiceExtensions
	{
		public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			
			services.AddTransient(typeof(IImageService), typeof(ImageService));
			
		}
	}
}
