using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WourkoutAPI.Data;
using WourkoutAPI.Interfaces;
using WourkoutAPI.Models;

namespace WourkoutAPI.Implementations
{
	public class AccountService : IAccountService
	{
		//private ApiDbContext _apiDbContext;

		public Task<bool> CheckLoginCredentials(string username, string password)
		{
			//var user = _apiDbContext.Accounts.Find()
			throw new Exception();
		}
	}
}
