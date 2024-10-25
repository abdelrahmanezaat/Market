using Application.Contract.IRepositories.ICommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Extensions
{
    public static class ServiceExtensions
	{
		public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
		{
			var connection = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<MarketContext>(options => options.UseSqlServer(connection));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}
	}
}
