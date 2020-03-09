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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WourkoutAPI.Data;
using WourkoutAPI.Helpers;
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

		[Authorize]
		[HttpGet("{userId}")]
		public IActionResult Get(int userId)
		{
			var user = _apiDbContext.Users.FirstOrDefault(u => u.Id == userId);

			if (user == null)
				return NotFound("User not found!");

			return Ok(user);
		}

		// PUT: api/User/5
		[Authorize]
		[HttpPut("{userId}")]
		public IActionResult Put(int userId, [FromBody] UserProfileView userProfileView)
		{
			#region Get info from jwt token
			//var request = Request;
			//// Make an function for getting authorization header out of tokenž
			//var token = TokenHelpers.GetValueFromHeader(request.Headers, "Authorization");
			#endregion
			var user = _apiDbContext.Users.FirstOrDefault(u => u.Id == userId);

			if (user == null)
				return NotFound("User not found!");

			user.Name = userProfileView.Name;
			user.DateOfBirth = userProfileView.DateOfBirth;
			user.Height = userProfileView.Height;
			user.Weight = userProfileView.Weight;
			user.BMI = userProfileView.BMI;

			if (_apiDbContext.SaveChanges() > 0) return StatusCode(StatusCodes.Status200OK);

			else return StatusCode(StatusCodes.Status400BadRequest);
		}



		// We can find user by reading account id from JWT token
		// DELETE: api/ApiWithActions/5
		[Authorize]
		[HttpDelete("{userId}")]
		public IActionResult Delete(int userId)
		{
			var userAccount = _apiDbContext.Accounts.Include(a => a.User).FirstOrDefault(a => a.User.Id == userId);
			if (userAccount == null)
				return NotFound("Account not found!");

			var user = userAccount.User;

			if (user == null)
				return NotFound("User not found!");
			_apiDbContext.Accounts.Remove(userAccount);
			_apiDbContext.Users.Remove(user);

			if (_apiDbContext.SaveChanges() > 0) return StatusCode(StatusCodes.Status200OK);

			else return StatusCode(StatusCodes.Status400BadRequest);

		}

		[AllowAnonymous]
		[HttpPost("[action]")]
		public async Task<IActionResult> Register([FromBody] RegistrationView view)
		{
			var account = new Account();
			var user = new User();

			if (view == null)
			{
				return BadRequest("Invalid registration data!");
			}

			var existingAccount = await FindUserByNameAsync(view.Username);

			// If user account already exists
			if (existingAccount.UserName != null && existingAccount.UserName == view.Username)
				return Conflict("Username already exists!");

			// Account information
			account.UserName = view.Username;
			var enchancedHashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(view.Password, hashType: BCrypt.Net.HashType.SHA384);
			account.Password = enchancedHashedPassword;

			// User information
			user.Name = view.Name;
			user.DateOfBirth = view.DateOfBirth;
			user.BMI = view.BMI;
			user.Weight = view.Weight;
			user.Height = view.Height;

			// Binding account and user
			account.User = user;

			_apiDbContext.Accounts.Add(account);
			_apiDbContext.Users.Add(user);

			if (_apiDbContext.SaveChanges() > 0)
			{
				var jwt = GenerateAccessToken(user.Id, account.UserName);
				return Ok(new { token = jwt });
			}

			else return StatusCode(StatusCodes.Status400BadRequest);
		}


		[AllowAnonymous]
		[HttpPost("[action]")]
		public async Task<IActionResult> Login([FromBody] LoginView view)
		{
			var account = await FindUserByNameAsync(view.Username);
			var credentialsValid = await CheckUserCredentials(account, view.Password);

			if (!credentialsValid)
			{
				return BadRequest("Wrong username or password!");
			}

			var user = account.User;
			if (user == null)
			{
				return NotFound("User not found!");
			}

			var jwt = GenerateAccessToken(user.Id, account.UserName);

			return Ok(new { token = jwt });
		}

		private Task<Account> FindUserByNameAsync(string username)
		{
			if (username != null)
			{
				var acc = _apiDbContext.Accounts.Include(a => a.User).FirstOrDefault(a => a.UserName == username);
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
			if (acc != null)
			{
				var verify = BCrypt.Net.BCrypt.EnhancedVerify(password, acc.Password, BCrypt.Net.HashType.SHA384);
				if (verify) return Task.FromResult(true);
			}
			return Task.FromResult(false);
		}

		public string GenerateAccessToken(int userId, string username)
		{
			// We are putting users Id nad account username into JWT claims
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, username),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
				new Claim(ClaimTypes.Name, username),
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

		//[AllowAnonymous]
		//[HttpPost("[action]/{password}")]
		//public string GenerateHashTest(string password)
		//{
		//	var enchancedHashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(password, hashType: BCrypt.Net.HashType.SHA384);
		//	return enchancedHashedPassword;
		//}

		//[AllowAnonymous]
		//[HttpPost("[action]/{password}")]
		//public string VerifyHashedPassword(string password)
		//{
		//	var enchancedHashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(password, hashType: BCrypt.Net.HashType.SHA384);
		//	var verify = BCrypt.Net.BCrypt.EnhancedVerify(password, enchancedHashedPassword, BCrypt.Net.HashType.SHA384);
		//	return verify ? "Verified" : "Not verified";
		//}
	}
}
