using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class WorkoutType
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[JsonIgnore]
		public bool UserMade { get; set; }
	}
}
