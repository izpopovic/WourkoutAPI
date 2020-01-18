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
		[HttpGet("[action]/workouttype/{workoutTypeId}/workoutDifficulty/{workoutDifficultyId}")]
		public IActionResult PredefinedWorkouts(int userId, int workoutTypeId, int workoutDifficultyId)
		{
			var user = _apiDbContext.Users.FirstOrDefault(u => u.Id == userId);
			if (user == null)
				return NotFound("User not found!");

			// Get Strength or Cardio predefined workout
			//var predefinedWorkouts = _apiDbContext.Workouts.Where(w => w.IsPredefined == true && w.WorkoutType.Id == workoutTypeId);
			// Who should be doing calculations of user hieght weight and BMI,
			// and depending on the info offer the best workout?
			// server side or client side?
			var predefinedWorkout = _apiDbContext.Workouts
				.FirstOrDefault(w => w.IsPredefined == true &&
								w.WorkoutType.Id == workoutTypeId &&
								w.WorkoutDifficulty.Id == workoutDifficultyId);

			if (predefinedWorkout == null)
			{
				return NotFound("There is no predefined workout of that type available");
			}
			return Ok(predefinedWorkout);
		}

		
		// Returns all workouts of that user
		// GET: api/User/1/Workouts
		[Authorize]
		[HttpGet]
		public IActionResult Get(int userId)
		{
			//var user = _apiDbContext.Users.Include(u => u.UserWorkouts)
			//	.FirstOrDefault(u => u.Id == userId);
			//if (user == null)
			//	return NotFound("User not found!");

			//var userWorkout = user.UserWorkouts;
			//if (userWorkout == null )
			//	return NotFound("User has no workouts!");

			//var workouts = userWorkout.Select(uw => uw.Workout);


			var user = _apiDbContext.Users.Include(u => u.UserWorkouts)
				.ThenInclude(u => u.Workout)
				.ThenInclude(w => w.WorkoutType)
				.FirstOrDefault(u => u.Id == userId);
			if (user == null)
				return NotFound("User not found!");

			var usersWorkout = user.UserWorkouts.Where(uw => uw.UserId == userId);
			if (usersWorkout == null)
				return NotFound("Workout not found!");

			var workouts = usersWorkout.Select(uw => uw.Workout);

			return Ok(workouts);
		}

		// Returns all Exercises of the specific Workout
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
				return NotFound("User not found!");
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
				.ThenInclude(ew => ew.Exercise)
				.ThenInclude(e => e.Category)
				//.AsNoTracking()
				.FirstOrDefault(u => u.Id == userId);
			if (user == null)
				return NotFound("User not found!");

			var workout = user.UserWorkouts.FirstOrDefault(uw => uw.WorkoutId == workoutId)?.Workout;
			if (workout == null)
				return NotFound("Workout not found!");

			//var exercise = workout.ExerciseWorkouts.FirstOrDefault(e => e.ExerciseId == exerciseId)?.Exercise;
			var exercise = _apiDbContext.Exercises/*.AsNoTracking()*/.Include(e => e.Category).FirstOrDefault(e => e.Id == exerciseId);
			if (exercise == null)
				return NotFound("Exercise not found!");
			// Populating new exercise

			var exerciseWorkout = new ExerciseWorkout();
			exerciseWorkout.Reps = addExerciseView.Reps;
			exerciseWorkout.Sets = addExerciseView.Sets;
			exerciseWorkout.Weight = addExerciseView.Weight;
			exerciseWorkout.Description = addExerciseView.Description;

			#region HowItWasBefore
			// Map exercise to workout
			//exerciseWorkout.Exercise = exercise;
			//exerciseWorkout.Workout = workout;

			// Binding exercise to workout
			//workout.ExerciseWorkouts.Add(exerciseWorkout);
			#endregion

			exerciseWorkout.WorkoutId = workoutId;
			exerciseWorkout.ExerciseId = exerciseId;

			// For now, if same exercise on same workout is trying to be added,
			// TO DO: Enable multiple exercises and workouts with same id
			//var sameExercise = workout.ExerciseWorkouts.FirstOrDefault(ew => ew.ExerciseId == exerciseId);
			//var sameWorkout = workout.ExerciseWorkouts.FirstOrDefault(ew => ew.WorkoutId == workoutId);
			//if (sameExercise != null && sameWorkout != null)
			//{
			//	return BadRequest("You cannot add same exercise twice inside of an single workout!");
			//}

			workout.ExerciseWorkouts.Add(exerciseWorkout);

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

			var workout = user.UserWorkouts.FirstOrDefault(uw => uw.WorkoutId == workoutId)?.Workout;
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

			var userWorkout = user.UserWorkouts.FirstOrDefault(uw => uw.WorkoutId == workoutId);
			if (userWorkout == null)
				return NotFound("Workout for this user not found!");

			var workout = userWorkout.Workout;
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
		[HttpDelete("{workoutId}")]
		public IActionResult Delete(int userId, int workoutId)
		{
			var user = _apiDbContext.Users.Include(u => u.UserWorkouts)
				.ThenInclude(uw => uw.Workout)
				.ThenInclude(w => w.ExerciseWorkouts)
				.FirstOrDefault(u => u.Id == userId);

			if (user == null)
				return NotFound("User not found!");

			// Locate workout and associated exercises from UserWorkout
			var userWorkout = user.UserWorkouts.FirstOrDefault(uw => uw.WorkoutId == workoutId);
			if (userWorkout == null)
				return NotFound("Users workout not found!");

			var workout = userWorkout.Workout;
			if (workout == null)
				return NotFound("Workout not found!");
			var workoutExercises = workout.ExerciseWorkouts.Where(ew => ew.WorkoutId == workoutId);

			// Delete all associated exercises (ExerciseWorkout)
			// Is there a better way*
			foreach (var item in workoutExercises.ToList())
			{
				workout.ExerciseWorkouts.Remove(item);
			}

			// Delete workout reference from UserWorkout
			user.UserWorkouts.Remove(userWorkout);
			// Delete the workout
			_apiDbContext.Workouts.Remove(workout);

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}

		// If you delete exercise, only that exercise for that workout for that user is deleted!
		// DELETE: api/User/1/Workouts/5

		[Authorize]
		[HttpDelete("{workoutId}/exercises/{exerciseId}")]
		public IActionResult Delete(int userId, int workoutId, int exerciseId)
		{
			var user = _apiDbContext.Users.Include(u => u.UserWorkouts)
				.ThenInclude(uw => uw.Workout)
				.ThenInclude(w => w.ExerciseWorkouts)
				.ThenInclude(ew => ew.Exercise)
				.FirstOrDefault(u => u.Id == userId);

			if (user == null)
				return NotFound("User not found!");

			// Locate workout and associated exercises from UserWorkout
			var userWorkout = user.UserWorkouts.FirstOrDefault(uw => uw.WorkoutId == workoutId);
			if (userWorkout == null)
				return NotFound("Users workout not found!");

			var workout = userWorkout.Workout;
			if (workout == null)
				return NotFound("Workout not found!");

			var workoutExercise = workout.ExerciseWorkouts.FirstOrDefault(ew => ew.ExerciseId == exerciseId);
			if (workoutExercise == null)
				return NotFound("Exercise for this workout not found!");

			workout.ExerciseWorkouts.Remove(workoutExercise);

			if (_apiDbContext.SaveChanges() > 0)
				return StatusCode(StatusCodes.Status200OK);

			else
				return StatusCode(StatusCodes.Status400BadRequest);
		}
	}
}
