﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class UserWorkout
	{
		public int WorkoutId { get; set; }
		[JsonIgnore]
		public virtual Workout Workout{ get; set; }
		public int UserId{ get; set; }
		[JsonIgnore]
		public virtual User User{ get; set; }
	}
}
