using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WourkoutAPI.Data;
using WourkoutAPI.Models;

namespace WourkoutAPI.Controllers
{
	[Route("api/User/{userId}/[controller]")]
	[ApiController]
	public class ExercisesController : ControllerBase
	{
		private ApiDbContext _apiDbContext;

		public ExercisesController(ApiDbContext apiDbContext)
		{
			_apiDbContext = apiDbContext;
		}

		// GET: api/Exercise
		[HttpGet]
		[Authorize]
		public IActionResult Get()
		{
			// Need to ensure not to pull all exercises at once
			// Possible caching with paging algorithm needed
			var exercises = _apiDbContext.Exercises;
			if (exercises != null)
			{
				return Ok(exercises.Include("Category"));
			}
			else
			{
				return StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpGet("[action]/{name}")]
		[Authorize]
		public IActionResult FindExerciseByName(string name)
		{
			var foundExercise = _apiDbContext.Exercises.FirstOrDefault(e => e.Name == name);
			if (foundExercise == null)
				return NotFound("Name of the exercise doesn't exist");
			else
			{
				var id = foundExercise.Id;
				return Ok(id);
			}
		}

		// GET: api/Exercise/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var exercise = _apiDbContext.Exercises.Include("Category").FirstOrDefault(e => e.Id == id);
			if (exercise == null)
			{
				return NotFound("Exercise not found! Try with a different one...");
			}
			else
			{
				return Ok(exercise);
			}
		}

		[HttpGet("[action]")]
		[Authorize]
		public IActionResult GetExerciseCategories()
		{
			var exerciseCategories = _apiDbContext.ExerciseCategories;
			if (exerciseCategories == null)
				return NotFound("Exercise categories not found");
			else
				return Ok(exerciseCategories);
		}

		[HttpGet("[action]/{categoryId}")]
		[Authorize]
		public IActionResult GetExercisesByCategory(int categoryId)
		{
			var exercises = _apiDbContext.Exercises.Where(e => e.Category.Id == categoryId);
			if (exercises == null)
				return NotFound("Exercise for this category not found");
			else
				return Ok(exercises);
		}
		#region Post, Put, Delete
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
		#endregion


	}
}
