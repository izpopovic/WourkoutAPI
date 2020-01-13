using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WourkoutAPI.Data;
using WourkoutAPI.Models;
using WourkoutAPI.ViewRepresantation;

namespace WourkoutAPI.Controllers
{
	[Route("api/User/{userId}/[controller]")]
	[ApiController]
	public class WorkoutsController : ControllerBase
	{

		private ApiDbContext _apiDbContext;

		public WorkoutsController(ApiDbContext apiDbContext)
		{
			_apiDbContext = apiDbContext;
		}
		// ALSO CREATE ENDPOINT TO GET PREDEFINED WORKOUT DATA FOR EXERCISES!

		// GET: api/User/2/Workouts/PredefinedWorkouts
		// Getting predefined workouts
		// Logic for getting predefined workouts based on height, weight and BMI
		[Authorize]
		[HttpGet("[action]")]
		public IEnumerable<string> PredefinedWorkouts()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/User/1/Workouts
		[Authorize]
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/User/1/Workouts/5
		[Authorize]
		[HttpGet("{workoutId}", Name = "Get")]
		public IActionResult Get(int userId, int workoutId)
		{

			// Find user
			var user = _apiDbContext.Users.Include(u => u.UserWorkouts).ThenInclude(u => u.Workout).
				ThenInclude(u => u.ExerciseWorkouts)
				/*ThenInclude(u => u.Workout.WorkoutDifficulty)*/.FirstOrDefault(u => u.Id == userId);
			if (user == null)
			{
				return NotFound("User not found!");
			}
			// Find workout under workoutId for that user

			var usersWorkout = user.UserWorkouts.FirstOrDefault(uw => uw.WorkoutId == workoutId);
			if (usersWorkout == null)
			{
				return NotFound("Workout not found!");
			}
			// Load workout information
			// Newly created workout can have 0 information on it, dont check nulls
			var workoutExercises = usersWorkout.Workout.ExerciseWorkouts.Where(ew => ew.WorkoutId == workoutId);
			return Ok(workoutExercises);
		}

		// POST: api/User/1/Workouts
		[Authorize]
		[HttpPost]
		public IActionResult Post(int userId, [FromBody] WorkoutView addWorkoutView)
		{
			var user = _apiDbContext.Users.Include(u => u.UserWorkouts).FirstOrDefault(u => u.Id == userId);
			if (user == null)
			{
				return NotFound("User not found");
			}
			var workout = new Workout();
			// User input
			workout.Name = addWorkoutView.Name;
			workout.Description = addWorkoutView.Description;
			workout.Duration = addWorkoutView.Duration;
			// Default input
			// 3 - custom workout type
			var workoutType = _apiDbContext.WorkoutTypes.FirstOrDefault(wt => wt.Id == 3);
			// 4 - custom workout difficulty
			var workoutDifficulty = _apiDbContext.WorkoutDifficulties.FirstOrDefault(wd => wd.Id == 4);

			workout.WorkoutType = workoutType;
			workout.WorkoutDifficulty = workoutDifficulty;
			workout.IsPredefined = false;

			var userWorkout = new UserWorkout();

			// Map user to workout
			userWorkout.User = user;
			userWorkout.Workout = workout;

			// Binding workout with user
			user.UserWorkouts.Add(userWorkout);

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}

		// POST: api/User/1/Workouts/1/exercises/3
		[Authorize]
		[HttpPost("{workoutId}/exercises/{exerciseId}")]
		public IActionResult Post(int userId, int workoutId, int exerciseId, [FromBody] ExerciseView addExerciseView)
		{

			var user = _apiDbContext.Users.Include(u => u.UserWorkouts)
				.ThenInclude(uw => uw.Workout)
				.ThenInclude(w => w.ExerciseWorkouts)
				//.ThenInclude(ew => ew.Exercise)
				//.ThenInclude(e => e.Category)
				.FirstOrDefault(u => u.Id == userId);
			if (user == null)
			{
				return NotFound("User not found!");
			}
			var exercise = _apiDbContext.Exercises.Include(e =>e.Category).FirstOrDefault(e => e.Id == exerciseId);
			if (exercise == null)
			{
				return NotFound("Exercise not found!");
			}
			// Populating new exercise
			var userWorkout = user.UserWorkouts.First(uw => uw.WorkoutId == workoutId).Workout;

			var exerciseWorkout = new ExerciseWorkout();
			exerciseWorkout.Reps = addExerciseView.Reps;
			exerciseWorkout.Sets = addExerciseView.Sets;
			exerciseWorkout.Weight = addExerciseView.Weight;
			exerciseWorkout.Description = addExerciseView.Description;

			// Map exercise to workout
			exerciseWorkout.Exercise = exercise;
			exerciseWorkout.Workout = userWorkout;

			// Binding exercise to workout
			userWorkout.ExerciseWorkouts.Add(exerciseWorkout);

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}

		// PUT: api/User/1/Workouts/4
		[Authorize]
		[HttpPut("{workoutId}")]
		public IActionResult Put(int userId, int workoutId, [FromBody] WorkoutView workoutView)
		{
			var user = _apiDbContext.Users.Include(u => u.UserWorkouts)
				.ThenInclude(uw => uw.Workout)
				.FirstOrDefault(u => u.Id == userId);
			if (user == null)
				return NotFound("User not found!");

			var workout = user.UserWorkouts.FirstOrDefault(uw => uw.WorkoutId == workoutId).Workout;
			if (workout == null)
				return NotFound("Workout not found!");

			workout.Name = workoutView.Name;
			workout.Description = workoutView.Description;
			workout.Duration = workoutView.Duration;

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}


		//PUT api/User/1/Workouts/4/exercises/2
		[Authorize]
		[HttpPut("{workoutId}/exercises/{exerciseId}")]
		public IActionResult Put(int userId, int workoutId, int exerciseId, [FromBody] ExerciseView exerciseView)
		{
			var user = _apiDbContext.Users.Include(u => u.UserWorkouts)
				.ThenInclude(uw => uw.Workout)
				.ThenInclude(w => w.ExerciseWorkouts)
				.ThenInclude(ew => ew.Exercise)
				.FirstOrDefault(u => u.Id == userId);
			if (user == null)
				return NotFound("User not found!");

			var workout = user.UserWorkouts.FirstOrDefault(uw => uw.WorkoutId == workoutId).Workout;
			if (workout == null)
				return NotFound("Workout not found!");
			var exerciseWorkout = workout.ExerciseWorkouts.FirstOrDefault(ew => ew.ExerciseId == exerciseId);
			if (exerciseWorkout == null)
				return NotFound("Exercise for this workout not found!");

			exerciseWorkout.Reps = exerciseView.Reps;
			exerciseWorkout.Sets = exerciseView.Sets;
			exerciseWorkout.Weight = exerciseView.Weight;
			exerciseWorkout.Description = exerciseView.Description;

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}

		// If you delete workout, all associated exercises must be deleted too!
		// If you delete exercise, only that exercise for that workout for that user is deleted!
		// DELETE: api/User/1/Workouts/5
		[Authorize]
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
