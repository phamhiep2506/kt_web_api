namespace Models;

public class ResponseProductDto
{
    public string? status { get; set; }
    public string? message { get; set; }
    public List<ProductDetail>? items { get; set; }
}
