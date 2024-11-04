using Domin.Entities.Category_realted;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ItemDtos
{
	public class CreateItemDto
	{
		public string Name { get; set; }
		public string Manufacturer { get; set; }
		public string Model { get; set; }
		public string Description { get; set; }
		public DateTimeOffset? ReleaseDate { get; set; }
		public string ExpriyDuration { get; set; }
		public IFormFile Image { get; set; }
		public Guid CategoryId { get; set; }
		
	}
}
