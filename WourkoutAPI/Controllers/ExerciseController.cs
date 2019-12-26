using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WourkoutAPI.Models;

namespace WourkoutAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExerciseController : ControllerBase
	{
		private ApiDbContext _apiDbContext;

		public ExerciseController(ApiDbContext apiDbContext)
		{
			_apiDbContext = apiDbContext;
		}

		// GET: api/Exercise
		[HttpGet]
		public IActionResult Get()
		{
			// Need to ensure not to pull all exercises at once
			// Possible caching with paging algorithm needed
			return Ok(_apiDbContext.Exercises);
		}

		// GET: api/Exercise/5
		[HttpGet("{id}", Name = "GetExercise")]
		public IActionResult Get(int id)
		{
			var exercise = _apiDbContext.Exercises.Find(id);
			if (exercise == null)
			{
				return NotFound("Exercise not found! Try with a different one...");
			}
			else
			{
				return Ok(exercise);
			}
		}

		// For now don't allow adding of new exercises
		// POST: api/Exercise
		//[HttpPost]
		//public StatusCodeResult Post([FromBody] Exercise exercise)
		//{
		//	if (exercise != null)
		//	{
		//		_apiDbContext.Exercises.Add(exercise);
		//		_apiDbContext.SaveChanges();
		//		return StatusCode(StatusCodes.Status201Created);
		//	}
		//	else
		//	{
		//		return StatusCode(StatusCodes.)
		//	}
		//}

		// PUT: api/Exercise/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		// DELETE: api/ApiWithActions/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
