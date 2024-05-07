using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string? ProductName { get; set; }

    public ICollection<Propertie>? Properties { get; set; }

    public ICollection<ProductDetailPropertyDetail>? ProductDetailPropertyDetails { get; set; }
}
