using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class Account
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string UserName { get; set; }
		[Required]
		[StringLength(50)]
		public string Password { get; set; }
		[StringLength(500)]
		public string PasswordHash { get; set; }
		//[Required]
		[StringLength(50)]
		public string Salt { get; set; }
		public virtual User User { get; set; }
	}
}
