namespace CarDealer.Models;

using System.ComponentModel.DataAnnotations;

public class Car
{
    public Car()
    {
        Sales = new List<Sale>();
        PartsCars = new List<PartCar>();
    }

    [Key]
    public int Id { get; set; }

    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public long TraveledDistance { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = null!;
    public virtual ICollection<PartCar> PartsCars { get; set; } = null!;
}
