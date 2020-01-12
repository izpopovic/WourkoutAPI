using System;
using System.ComponentModel.DataAnnotations;

namespace WourkoutAPI.Models
{
	public class PlannerView
	{
		[Required]
		public DateTime PlanningDate { get; set; }
		[Required]
		[StringLength(2000)]
		public string QuickNotes { get; set; }
		[Required]
		public int UserId { get; set; }
	}
}
