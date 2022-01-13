using System.Linq;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Data
{
  public static class DbInitializer
  {
    public static void Initialize(WorkoutTrackerContext context)
    {
      context.Database.EnsureCreated();

      if (context.Users.Any())
      {
        return;
      }

      User user = new() { Id = 1, Name = "cj" };
      context.Users.Add(user);
      context.SaveChanges();

      var exercises = new Exercise[]
      {
        new() {Id = 1, Name = "Row", BodyPart = BodyPart.Back},
        new() {Id = 2, Name = "Chest press inclined", BodyPart = BodyPart.Chest},
        new() {Id = 3, Name = "Squat", BodyPart = BodyPart.Legs},
        new() {Id = 4, Name = "Dead-lift", BodyPart = BodyPart.All},
        new() {Id = 5, Name = "Shoulder press", BodyPart = BodyPart.Shoulders},
        new() {Id = 6, Name = "Power clean", BodyPart = BodyPart.Biceps},
        new() {Id = 7, Name = "Pull-up", BodyPart = BodyPart.Core | BodyPart.Back | BodyPart.Shoulders},
        new() {Id = 8, Name = "Lat pull-down", BodyPart = BodyPart.Back},
        new() {Id = 9, Name = "Triceps", BodyPart = BodyPart.Triceps},
        new() {Id = 10, Name = "Plank", BodyPart = BodyPart.Core},
        new() {Id = 11, Name = "Biceps curl", BodyPart = BodyPart.Biceps},
        new() {Id = 12, Name = "Pushups", BodyPart = BodyPart.Chest},
        new() {Id = 13, Name = "Chest press standard", BodyPart = BodyPart.Chest}
      };

      foreach (var exercise in exercises)
      {
        context.Exercises.Add(exercise);
      }

      context.SaveChanges();

      var workoutProgresses = new WorkoutProgress[]
      {
        new() {Id = 1, UserId = 1, ExerciseId = 1, Repetitions = 6, Sets = 4, Weight = 40, EquipmentType = EquipmentType.BigBarbell},
        new() {Id = 2, UserId = 1, ExerciseId = 2, Repetitions = 6, Sets = 4, Weight = 10, EquipmentType = EquipmentType.BigBarbell},
        new() {Id = 3, UserId = 1, ExerciseId = 3, Repetitions = 6, Sets = 4, Weight = 11.5m, EquipmentType = EquipmentType.BigBarbell},
        new() {Id = 4, UserId = 1, ExerciseId = 4, Repetitions = 7, Sets = 4, Weight = 45, EquipmentType = EquipmentType.SmallBarbell},
        new() {Id = 5, UserId = 1, ExerciseId = 5, Repetitions = 8, Sets = 4, Weight = 10, EquipmentType = EquipmentType.Dumbbell},
        new() {Id = 6, UserId = 1, ExerciseId = 5, Repetitions = 6, Sets = 4, Weight = 20, EquipmentType = EquipmentType.SmallBarbell},
        new() {Id = 7, UserId = 1, ExerciseId = 13, Repetitions = 6, Sets = 4, Weight = 12.5m, EquipmentType = EquipmentType.BigBarbell},
        new() {Id = 8, UserId = 1, ExerciseId = 6, Repetitions = 6, Sets = 4, Weight = 20, EquipmentType = EquipmentType.SmallBarbell},
        new() {Id = 9, UserId = 1, ExerciseId = 7, Repetitions = 12, Sets = 4, Weight = 35, EquipmentType = EquipmentType.Machine},
        new() {Id = 10, UserId = 1, ExerciseId = 13, Repetitions = 6, Sets = 4, Weight = 20, EquipmentType = EquipmentType.Dumbbell},
        new() {Id = 11, UserId = 1, ExerciseId = 1, Repetitions = 6, Sets = 4, Weight = 35, EquipmentType = EquipmentType.Machine},
        new() {Id = 12, UserId = 1, ExerciseId = 8, Repetitions = 6, Sets = 4, Weight = 20, EquipmentType = EquipmentType.Machine},
        new() {Id = 13, UserId = 1, ExerciseId = 9, Repetitions = 6, Sets = 4, Weight = 15, EquipmentType = EquipmentType.Machine},
        new() {Id = 14, UserId = 1, ExerciseId = 3, Repetitions = 12, Sets = 4, Weight = 25, EquipmentType = EquipmentType.Sandbag},
        new() {Id = 15, UserId = 1, ExerciseId = 10, Repetitions = 1, Sets = 3, Weight = 0, EquipmentType = EquipmentType.None, TempoTraining = "1-60-x-1"},
        new() {Id = 16, UserId = 1, ExerciseId = 11, Repetitions = 6, Sets = 4, Weight = 25, EquipmentType = EquipmentType.SmallBarbell},
        new() {Id = 17, UserId = 1, ExerciseId = 12, Repetitions = 17, Sets = 5, Weight = 0, EquipmentType = EquipmentType.None}
      };

      foreach (var workoutProgress in workoutProgresses)
      {
        context.WorkoutProgresses.Add(workoutProgress);
      }

      context.SaveChanges();
    }
  }
}
