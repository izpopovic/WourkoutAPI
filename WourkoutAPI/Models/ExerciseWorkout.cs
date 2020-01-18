using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WourkoutAPI.Models
{
	public class ExerciseWorkout
	{
		public int Id { get; set; }
		[StringLength(50)]
		public string Reps { get; set; }
		[StringLength(50)]
		public string Sets { get; set; }
		public double Weight { get; set; }
		[StringLength(1000)]
		public string Description { get; set; }
		public int WorkoutId { get; set; }
		[JsonIgnore]
		public virtual Workout Workout { get; set; }
		public int ExerciseId { get; set; }
		[JsonIgnore]
		public virtual Exercise Exercise { get; set; }

	}
}
