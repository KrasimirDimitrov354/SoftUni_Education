namespace ProductShop.DTOs.Export;

using Newtonsoft.Json;

public class SellerDTO
{
    [JsonProperty("lastName")]
    public string SellerLastName { get; set; } = null!;

    [JsonProperty("age")]
    public int? Age { get; set; }

    [JsonProperty("soldProducts")]
    public SoldProductsTotalDTO SoldProductsTotal { get; set; } = null!;
}

