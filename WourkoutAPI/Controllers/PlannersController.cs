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
	public class PlannersController : ControllerBase
	{
		private ApiDbContext _apiDbContext;

		public PlannersController(ApiDbContext apiDbContext)
		{
			_apiDbContext = apiDbContext;
		}

		[Authorize]
		[HttpGet]
		public IActionResult Get(int userId)
		{
			var user = _apiDbContext.Users.Include(u => u.Planners).FirstOrDefault(u => u.Id == userId);
			if (user == null)
			{
				return NotFound("User not found!");
			}
			// It's okay not to have any planner defined so we can return null
			return Ok(user.Planners);
		}

		// POST: api/User/{userId}/planners
		[Authorize]
		[HttpPost]
		public IActionResult Post([FromBody] PlannerView view, int userId)
		{
			var user = _apiDbContext.Users.Include(u => u.Planners).FirstOrDefault(u => u.Id == userId);
			if (user == null)
				return NotFound("User not found!");

			var userPlanners = user.Planners;
			var planner = new Planner();

			planner.PlanningDate = view.PlanningDate;
			planner.QuickNotes = view.QuickNotes;

			userPlanners.Add(planner);

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}

		// PUT: api/User/{userId}/planners/5
		[Authorize]
		[HttpPut("{plannerId}")]
		public IActionResult Put(int plannerId, [FromBody] PlannerView view)
		{
			var planner = _apiDbContext.Planners.FirstOrDefault(p => p.Id == plannerId);

			if (planner == null)
				return NotFound("Planner not found!");

			planner.PlanningDate = view.PlanningDate;
			planner.QuickNotes = view.QuickNotes;

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}

		// DELETE: api/User/{userId}/planners/5
		[Authorize]
		[HttpDelete("{plannerId}")]
		public IActionResult Delete(int plannerId)
		{
			var planner = _apiDbContext.Planners.FirstOrDefault(p => p.Id == plannerId);

			if (planner == null)
				return NotFound("Planner not found!");

			_apiDbContext.Planners.Remove(planner);

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}
	}
}
