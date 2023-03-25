namespace CarDealer.Models;

using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer()
    {
        Sales = new HashSet<Sale>();
    }

    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public bool IsYoungDriver { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = null!;
}