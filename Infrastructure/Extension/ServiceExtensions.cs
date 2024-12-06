using Application.Contract.IInfrastructure;
using Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
		
				services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));

				services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = false;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidIssuer = configuration["JwtSetting:Issuer"],
						ValidAudience = configuration["JwtSetting:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"])),
						ClockSkew = TimeSpan.Zero
					};
				});

				services.AddTransient(typeof(IImageService), typeof(ImageService));
			services.AddTransient(typeof(IPasswordHashService), typeof(PasswordHashService));
			services.AddScoped(typeof(IJwtService), typeof(JwtService));
		}
	}
}
