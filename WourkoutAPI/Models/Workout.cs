using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class Workout
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(150)]
		public string Description { get; set; }
		[Required]
		public int Duration { get; set; }
		public virtual WorkoutType WorkoutType { get; set; }
		[JsonIgnore]
		public virtual WorkoutDifficulty WorkoutDifficulty { get; set; }
		public virtual ICollection<ExerciseWorkout> ExerciseWorkouts { get; set; }
		public virtual ICollection<UserWorkout> UserWorkouts { get; set; }
	}
}
