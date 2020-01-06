using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class ExerciseWorkout
	{
		public int WorkoutId { get; set; }
		public virtual Workout Workout { get; set; }
		public int ExerciseId { get; set; }
		public virtual Exercise Exercise { get; set; }
		[StringLength(50)]
		public string Reps { get; set; }
		[StringLength(50)]
		public string Sets { get; set; }
		public double Weight { get; set; }
		[StringLength(1000)]
		public string Description { get; set; }

	}
}
