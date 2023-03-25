namespace ProductShop.DTOs.Export;

using Newtonsoft.Json;

public class SoldProductDTO
{
    [JsonProperty("name")]
    public string ProductName { get; set; } = null!;

    [JsonProperty("price")]
    public decimal ProductPrice { get; set; }
}
