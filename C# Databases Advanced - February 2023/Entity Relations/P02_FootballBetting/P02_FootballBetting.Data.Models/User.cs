namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class User
{
    public User()
    {
        Bets = new HashSet<Bet>();
    }

    [Key]
    public int UserId { get; set; }

    [MaxLength(PropertyLengthValidation.UserNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(PropertyLengthValidation.UserUsernameMaxLength)]
    public string Username { get; set; } = null!;

    [MaxLength(PropertyLengthValidation.UserPasswordMaxLength)]
    public string Password { get; set; } = null!;

    [MaxLength(PropertyLengthValidation.UserEmailMaxLength)]
    public string Email { get; set; } = null!;

    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; } = null!;
}
