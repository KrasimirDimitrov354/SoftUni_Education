namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Game
{
    public Game()
    {
        Bets = new HashSet<Bet>();
        PlayersStatistics = new HashSet<PlayerStatistic>();
    }

    [Key]
    public int GameId { get; set; }

    public DateTime DateTime { get; set; }

    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; } = null!;

    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = null!;

    [MaxLength(PropertyLengthValidation.GameResultMaxLength)]
    public string Result { get; set; } = null!;

    public byte HomeTeamGoals { get; set; }
    public byte AwayTeamGoals { get; set; }

    public double HomeTeamBetRate { get; set; }
    public double AwayTeamBetRate { get; set; }
    public double DrawBetRate { get; set; }
    public virtual ICollection<Bet> Bets { get; set; } = null!;

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = null!;
}
