﻿namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class ImportCarDTO
{
    [JsonProperty("make")]
    public string Make { get; set; } = null!;

    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [JsonProperty("traveledDistance")]
    public long TraveledDistance { get; set; }

    [JsonProperty("partsId")]
    public int[] PartsIds { get; set; } = null!;
}
