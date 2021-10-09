using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Data.Models
{
  public class Exercise
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }

    public BodyPart BodyPart { get; set; }
  }

  [Flags]
  public enum BodyPart
  {
    All = 0,
    Legs = 1,
    Chest = 2,
    Biceps = 4,
    Triceps = 8,
    Back = 16,
    Shoulders = 32,
    Core = 64
  }
}
