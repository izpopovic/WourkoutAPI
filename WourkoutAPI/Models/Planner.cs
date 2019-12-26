using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class Planner
	{
		public int Id { get; set; }
		[Required]
		public DateTime PlanningDate { get; set; }
		[Required]
		[StringLength(2000)]
		public string QuickNotes { get; set; }
	}
}
