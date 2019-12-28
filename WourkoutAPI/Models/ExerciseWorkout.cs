using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class ExerciseWorkout
	{
		public int ExerciseId { get; set; }
		public virtual Exercise Exercise { get; set; }
		public int WorkoutId { get; set; }
		public virtual Workout Workout { get; set; } 
		public int Sets { get; set; }
		public int Reps { get; set; }
	}
}
