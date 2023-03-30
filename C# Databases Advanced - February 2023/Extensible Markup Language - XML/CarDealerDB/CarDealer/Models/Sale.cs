namespace CarDealer.Models;

public class Sale
{
    public int Id { get; set; }

    public decimal Discount { get; set; }

    public int CarId { get; set; }
    public virtual Car Car { get; set; } = null!;    

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;

    public decimal CalculateSaleSum()
    {
        return this.Customer.IsYoungDriver 
            ? this.Car.CalculateCarPrice() - (this.Car.CalculateCarPrice() * 0.05m)
            : this.Car.CalculateCarPrice();
    }
}
