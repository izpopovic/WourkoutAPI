using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.ViewRepresantation
{
	public class RegistrationView
	{
		[Required]
		[StringLength(50)]
		public string Username { get; set; }
		[Required]
		[StringLength(50)]
		public string Password { get; set; }
		//[Required]
		[StringLength(60)]
		public string Name { get; set; }
		//[Required]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
		//[Required]
		public int Height { get; set; }
		//[Required]
		public double Weight { get; set; }
		//[Required]
		public double BMI { get; set; }
	}
}
