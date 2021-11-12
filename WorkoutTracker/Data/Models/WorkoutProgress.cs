using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Data.Models
{
  public class WorkoutProgress
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int Repetitions { get; set; }
    public int Sets { get; set; }
    public decimal Weight { get; set; }
    public EquipmentType EquipmentType { get; set; }
    public string TempoTraining { get; set; }

    public int UserId { get; set; }
    public int ExerciseId { get; set; }

    public User User { get; set; }
    public Exercise Exercise { get; set; }
  }
}
