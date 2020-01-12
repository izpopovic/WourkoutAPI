using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.ViewRepresantation
{
	public class UserProfileView
	{
		[Required]
		[StringLength(60)]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
		[Required]
		public double Height { get; set; }
		[Required]
		public double Weight { get; set; }
		[Required]
		public double BMI { get; set; }
	}
}
