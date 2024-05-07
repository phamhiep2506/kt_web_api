using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Propertie
{
    [Key]
    public int PropertyId { get; set; }

    public int ProductId { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string? PropertyName { get; set; }

    public int PropertySort { get; set; }

    public Product? Product { get; set; }

    public ICollection<PropertyDetail>? PropertyDetails { get; set; }
}
