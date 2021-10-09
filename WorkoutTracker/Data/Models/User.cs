using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Data.Models
{
  public class User
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
