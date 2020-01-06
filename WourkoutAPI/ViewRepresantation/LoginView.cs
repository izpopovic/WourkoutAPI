using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.ViewRepresantation
{
	public class LoginView
	{
		[Required(ErrorMessage = "Username is required!")]
		[StringLength(50)]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required!")]
		[StringLength(50)]
		public string Password { get; set; }

	}
}
