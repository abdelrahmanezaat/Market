using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos.AuthDtos
{
	public class AuthDto
	{
		public string Message { get; set; }
		public string Email { get; set; }
		public string FullName { get; set; }
		public string ProfilePictureUrl { get; set; }
		public bool IsEmailConfirmed { get; set; }
		public List<string> Roles { get; set; }
		public string AccessToken { get; set; }
		public DateTime AccessTokenExpirationDate { get; set; }
		public string RefreshToken { get; set; }
		public DateTimeOffset RefreshTokenExpirationDate { get; set; }
	}
}
