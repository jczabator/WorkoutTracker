using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Data.Models
{
  public enum EquipmentType
  {
    None,
    [Display(Name="Big Barbell")]
    BigBarbell,
    [Display(Name = "Small Barbell")]
    SmallBarbell,
    Dumbbell,
    Machine,
    Sandbag,
    [Display(Name = "Bulgarian Bag")]
    BulgarianBag
  }
}