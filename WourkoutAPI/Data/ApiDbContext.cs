using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Models
{
	public class ApiDbContext : DbContext
	{
		public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
		public DbSet<WorkoutType> WorkoutTypes{ get; set; }
		public DbSet<WorkoutDifficulty> WorkoutDifficulties { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<Workout> Workouts { get; set; }
		public DbSet<Planner> Planners { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Exercise - Workout (many to many relation)
			modelBuilder.Entity<ExerciseWorkout>()
				.HasKey(ew => new { ew.ExerciseId, ew.WorkoutId});
			modelBuilder.Entity<ExerciseWorkout>()
				.HasOne(ew => ew.Workout)
				.WithMany(w => w.ExerciseWorkouts)
				.HasForeignKey(ew => ew.WorkoutId);
			modelBuilder.Entity<ExerciseWorkout>()
				.HasOne(ew => ew.Exercise)
				.WithMany(e => e.ExerciseWorkouts)
				.HasForeignKey(ew => ew.ExerciseId);

			// Workout - User (many to many relation)
			modelBuilder.Entity<UserWorkout>()
			.HasKey(uw => new { uw.UserId, uw.WorkoutId});
			modelBuilder.Entity<UserWorkout>()
				.HasOne(uw => uw.Workout)
				.WithMany(w => w.UserWorkouts)
				.HasForeignKey(uw => uw.WorkoutId);
			modelBuilder.Entity<UserWorkout>()
				.HasOne(uw => uw.User)
				.WithMany(u => u.UserWorkouts)
				.HasForeignKey(uw => uw.UserId);

			// Unique columns
			modelBuilder.Entity<Exercise>()
				.HasIndex(e => e.Name)
				.IsUnique();
			modelBuilder.Entity<ExerciseCategory>()
				.HasIndex(e => e.Name)
				.IsUnique();
			modelBuilder.Entity<WorkoutDifficulty>()
				.HasIndex(wd => wd.Name)
				.IsUnique();
			modelBuilder.Entity<WorkoutType>()
				.HasIndex(wt => wt.Name)
				.IsUnique();
		}
	}
}


