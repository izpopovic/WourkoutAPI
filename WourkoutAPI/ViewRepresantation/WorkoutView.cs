using System.ComponentModel.DataAnnotations;

namespace WourkoutAPI.ViewRepresantation
{
	public class WorkoutView
	{
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(1000)]
		public string Description { get; set; }
		[Required]
		public int Duration { get; set; }
	}
}
