using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IInfrastructure
{
	 public interface IImageService
	{
		string SetImage(IFormFile imgFile);
		void DeleteImage(string? imgUrl);
	}
}
