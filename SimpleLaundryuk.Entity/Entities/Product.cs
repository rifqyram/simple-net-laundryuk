using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLaundryuk.Entity.Entities;

[Table(name: "m_product")]
public class Product : EntityBase
{
    [Column(name: "name")] public string Name { get; set; } = string.Empty;
    [Column(name: "duration")] public int Duration { get; set; }

    public ICollection<ProductPrice>? ProductPrices { get; set; }
}