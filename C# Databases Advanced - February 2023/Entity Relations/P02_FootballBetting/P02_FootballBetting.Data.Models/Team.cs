﻿namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Team
{
    public Team()
    {
        HomeGames = new HashSet<Game>();
        AwayGames = new HashSet<Game>();
        Players = new HashSet<Player>();
    }

    [Key]
    public int TeamId { get; set; }

    [MaxLength(PropertyLengthValidation.TeamNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(PropertyLengthValidation.TeamUrlMaxLength)]
    public string? LogoUrl { get; set; }

    [MaxLength(PropertyLengthValidation.TeamInitialsMaxLength)]
    public string Initials { get; set; } = null!;

    public decimal Budget { get; set; }

    public int PrimaryKitColorId { get; set; }
    public virtual Color PrimaryKitColor { get; set; } = null!;

    public int SecondaryKitColorId { get; set; }
    public virtual Color SecondaryKitColor { get; set; } = null!;

    [ForeignKey(nameof(Town))]
    public int TownId { get; set; }
    public virtual Town Town { get; set; } = null!;

    public virtual ICollection<Game> HomeGames { get; set; } = null!;
    public virtual ICollection<Game> AwayGames { get; set; } = null!;
    public virtual ICollection<Player> Players { get; set; } = null!;
}