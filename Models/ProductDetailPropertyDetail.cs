using System.ComponentModel.DataAnnotations;

namespace Models;

public class ProductDetailPropertyDetail
{
    [Key]
    public int ProductDetailPropertyDetailId { get; set; }

    public int ProductDetailId { get; set; }

    public int PropertyDetailId { get; set; }

    public int ProductId { get; set; }

    public Product? Product { get; set; }

    public PropertyDetail? PropertyDetail { get; set; }

    public ProductDetail? ProductDetail { get; set; }
}
