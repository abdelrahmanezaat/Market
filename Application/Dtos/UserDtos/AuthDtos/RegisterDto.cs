using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos.AuthDtos
{
	public class RegisterDto
	{
		[EmailAddress, StringLength(128)]
		public string Email { get; set; }
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
			ErrorMessage = "The password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
		public string Password { get; set; }
		public string FullName { get; set; }
		public IFormFile ProfilePicture { get; set; }
	}
}
