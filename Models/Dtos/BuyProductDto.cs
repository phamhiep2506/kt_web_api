using System.ComponentModel.DataAnnotations;

namespace Models.Dtos;

public class BuyProductDto
{
    [MaxLength(50, ErrorMessage = "Tên không được dài quá 100 kí tự")]
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
}
