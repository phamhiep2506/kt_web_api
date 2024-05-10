namespace Models.Dtos;

public class ResponseBuyProductDto
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int BuyQuantity { get; set; }
    public int CurrentQuantity { get; set; }
    public float Price { get; set; }
    public float SumPrice { get; set; }
}
