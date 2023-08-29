namespace SoftUniBazar.Models;

public class AdBuyer
{
    public string BuyerId { get; set; } = null!;
    public virtual BazaarUser Buyer { get; set; } = null!;

    public int AdId { get; set; }
    public virtual Ad Ad { get; set; } = null!;
}
