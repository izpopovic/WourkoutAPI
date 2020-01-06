using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WourkoutAPI.Data;
using WourkoutAPI.Interfaces;
using WourkoutAPI.Models;
using WourkoutAPI.Settings;
using WourkoutAPI.ViewRepresantation;

namespace WourkoutAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private ApiDbContext _apiDbContext;
		private JwtSettings _jwtSettings;
		public UserController(ApiDbContext apiDbContext, IOptions<JwtSettings> jwtSettings)
		{
			_apiDbContext = apiDbContext;
			_jwtSettings = jwtSettings.Value;
		}

		// GET: api/User
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/User/5
		//[HttpGet("{id}", Name = "GetUser")]
		//public IActionResult Get(int id)
		//{
		//    //jwt ?

		//}

		// POST: api/User
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT: api/User/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		[HttpPost("[action]")]
		[AllowAnonymous]
		public async Task<IActionResult> Register([FromBody] RegistrationView view)
		{
			var account = new Account();
			var user = new User();

			if (view == null)
			{
				return BadRequest("Invalid registration data!");
			}

			var existingAccount = await FindUserByNameAsync(view.Username);
			// existingAccount.UserName can be null, might break?
			if (existingAccount.UserName != null && existingAccount.UserName == view.Username)
			{
				return StatusCode(StatusCodes.Status409Conflict);
			}
			// Account information
			account.UserName = view.Username;
			account.Password = view.Password;

			// User information
			user.Name = view.Name;
			user.DateOfBirth = view.DateOfBirth;
			user.BMI = view.BMI;
			user.Weight = view.Weight;
			user.Height = view.Height;

			_apiDbContext.Accounts.Add(account);
			_apiDbContext.Users.Add(user);
			
			if (_apiDbContext.SaveChanges() > 0)
			{
				return StatusCode(StatusCodes.Status201Created);
			}
			else
			{
				return StatusCode(StatusCodes.Status400BadRequest);
			}
		}


		[HttpPost("[action]")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] LoginView view)
		{
			var account = await FindUserByNameAsync(view.Username);
			var credentialsValid = await CheckUserCredentials(account, view.Password);

			if (!credentialsValid)
			{
				return BadRequest("Wrong username or password!");
			}

			var jwt = GenerateAccessToken(account.Id, account.UserName);

			return Ok(new { token = jwt });
		}

		private Task<Account> FindUserByNameAsync(string username)
		{
			if (username != null)
			{
				var acc = _apiDbContext.Accounts.FirstOrDefault(a => a.UserName == username);
				if (acc != null)
				{
					return Task.FromResult(acc);
				}
			}
			return Task.FromResult(new Account());
		}

		private Task<bool> CheckUserCredentials(Account account, string password)
		{
			var acc = _apiDbContext.Accounts.FirstOrDefault(a => a.UserName == account.UserName);
			if (acc.UserName != null)
			{
				if (acc.Password == password)
				{
					return Task.FromResult(true);
				}
			}
			return Task.FromResult(false);
		}

		public string GenerateAccessToken(int id, string username)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, username),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, id.ToString()),
				new Claim(ClaimTypes.Name, username)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				_jwtSettings.AuthorityURL,
				_jwtSettings.AuthorityURL,
				claims,
				expires: DateTime.Now.AddDays(_jwtSettings.ExpireTime),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}



	}
}
