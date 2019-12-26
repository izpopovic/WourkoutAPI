using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class Exercise
	{
		public int Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[Required]
		[JsonIgnore]
		public bool UserMade { get; set; }
		[Required]
		public virtual ExerciseCategory Category { get; set; }
		public virtual ICollection<ExerciseWorkout> ExerciseWorkouts { get; set; }
	}
}
