using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class ProductDetail
{
    [Key]
    public int ProductDetailId { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string? ProductPropertyName { get; set; }

    public int Quantity { get; set; }

    [MaxLength(53)]
    public float Price { get; set; }

    [MaxLength(53)]
    public float ShellPrice { get; set; }

    public int ParentId { get; set; }

    public ICollection<ProductDetailPropertyDetail>? ProductDetailPropertyDetails { get; set; }
}
