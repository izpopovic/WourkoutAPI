using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.ViewRepresantation
{
	public class ExerciseView
	{ 
		[StringLength(50)]
		public string Reps { get; set; }
		[StringLength(50)]
		public string Sets { get; set; }
		public double Weight { get; set; }
		[StringLength(1000)]
		public string Description { get; set; }
	}
}
