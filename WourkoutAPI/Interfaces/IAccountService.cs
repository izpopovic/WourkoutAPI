using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WourkoutAPI.Models;

namespace WourkoutAPI.Interfaces
{
	public interface IAccountService
	{
		Task<bool> CheckLoginCredentials(string username, string password);
	}
}
