using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		[StringLength(60)]
		public string Name { get; set; }
		[Required]
		public DateTime DateOfBirth { get; set; }
		[Required]
		public double BMI { get; set; }
		[Required]
		public double Weight { get; set; }
		[Required]
		public double Height { get; set; }
		public virtual ICollection<UserWorkout> UserWorkouts { get; set; }
		public virtual ICollection<Planner> Planners { get; set; }
	}
}
