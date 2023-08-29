namespace SoftUniBazar.Models;

using Microsoft.AspNetCore.Identity;

public class BazaarUser : IdentityUser
{
    public BazaarUser()
    {
        OwnedAds = new HashSet<Ad>();
        BoughtAds = new HashSet<Ad>();
    }

    public virtual ICollection<Ad> OwnedAds { get; set; }
    public virtual ICollection<Ad> BoughtAds { get; set; }
}
