using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IInfrastructure
{
	public interface IPasswordHashService
	{
		string Hash(string password);
		bool Verify(string passwordHash, string inputPassword);
	}
}
