using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contract.IInfrastructure;
using Domin.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace Infrastructure.Service
{
	public class ImageService:IImageService
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ImageService(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
		}

		public string SetImage(IFormFile imgFile)
		{
			var imgGuid = Guid.NewGuid();
			string imgExtension = Path.GetExtension(imgFile.FileName);
			string imgName = imgGuid + imgExtension;
			string imgUrl = Constants.IMAGE_FOLDER_PATH + imgName;

			string imgPath = _webHostEnvironment.WebRootPath + imgUrl;
			using var imgStream = new FileStream(imgPath, FileMode.Create);
			imgFile.CopyTo(imgStream);
			return imgUrl;
		}

		public void DeleteImage(string? imgUrl)
		{
			if (!string.IsNullOrEmpty(imgUrl))
			{
				var imgOldPath = _webHostEnvironment.WebRootPath + imgUrl;

				if (File.Exists(imgOldPath))
				{
					File.Delete(imgOldPath);
				}
			}
		}
	}
}
