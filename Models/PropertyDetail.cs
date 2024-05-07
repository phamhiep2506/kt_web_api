using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class PropertyDetail
{
    [Key]
    public int PropertyDetailId { get; set; }

    public int PropertyId { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string? PropertyDetailCode { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string? PropertyDetailDetail { get; set; }

    public Propertie? Propertie { get; set; }

    public ICollection<ProductDetailPropertyDetail>? ProductDetailPropertyDetails { get; set; }
}
