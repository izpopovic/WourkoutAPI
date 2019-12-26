using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class WorkoutDifficulty
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		//public virtual ICollection<Workout> Workouts { get; set; }
	}
}
