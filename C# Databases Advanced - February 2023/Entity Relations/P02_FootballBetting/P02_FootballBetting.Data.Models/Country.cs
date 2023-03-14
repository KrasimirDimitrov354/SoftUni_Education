﻿namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Country
{
    public Country()
    {
        Towns = new HashSet<Town>();
    }

    [Key]
    public int CountryId { get; set; }

    [MaxLength(PropertyLengthValidation.CountryNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Town> Towns { get; set; } = null!;
}
