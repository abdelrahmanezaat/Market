using Application.Contract.IFeatures;
using Application.Contract.IFeatures.ICategory;
using Application.Contract.IFeatures.IChat;
using Application.Contract.IFeatures.IItem;
using Application.Contract.IFeatures.IOrder;
using Application.Contract.IUser;
using Application.Features.Category_Related_Imp;
using Application.Features.Chat_Realted_imp;
using Application.Features.Common;
using Application.Features.Item_Related_Imp;
using Application.Features.Order_Related;
using Application.Features.User_Related_Imp;
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

			//Item
			services.AddScoped(typeof(IItemService), typeof(ItemService));


			// User
			services.AddScoped(typeof(IAuthService), typeof(AuthService));

			// Order 
			services.AddScoped(typeof(IOrderService), typeof(OrderService));
			// Chat
			services.AddScoped(typeof(IChatService), typeof(ChatService));
			services.AddScoped(typeof(IMessageService), typeof(MessageService));


		}
	}
}
