namespace ProductShop.DTOs.Export;

using Newtonsoft.Json;

public class SoldProductsTotalDTO
{
    [JsonProperty("count")]
    public int ProductsCount { get; set; }

    [JsonProperty("products")]
    public SoldProductDTO[] soldProducts { get; set; } = null!;
}
