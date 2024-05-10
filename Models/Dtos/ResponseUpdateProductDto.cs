namespace Models.Dtos;

public class ResponseUpdateProductDto
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
}
