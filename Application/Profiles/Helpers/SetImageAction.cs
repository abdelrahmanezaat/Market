using Application.Contract.IInfrastructure;
using AutoMapper;
using Domin.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles.Helpers
{
	public class SetImageAction<TSource, TDestination> : IMappingAction<TSource, TDestination>
		where TSource : class
		where TDestination : class
	{
		private readonly IImageService _imageService;

		public SetImageAction(IImageService imageService)
		{
			_imageService = imageService;
		}

		public void Process(TSource source, TDestination destination, ResolutionContext context)
		{
			var sourceImageProperty = typeof(TSource).GetProperty(Constants.IMAGE);
			var destinationImageProperty = typeof(TDestination).GetProperty(Constants.IMAGE_URL);

			if (sourceImageProperty != null && destinationImageProperty != null)
			{
				var image = sourceImageProperty.GetValue(source) as IFormFile;

				if (image != null)
				{
					destinationImageProperty.SetValue(destination, _imageService.SetImage(image));
				}
			}
		}
	}
}
