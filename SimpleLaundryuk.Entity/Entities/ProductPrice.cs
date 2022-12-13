using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLaundryuk.Entity.Entities;

[Table(name: "m_product_price")]
public class ProductPrice : EntityBase
{
    [Column(name: "price")] public int Price { get; set; }
    [Column(name: "is_active")] public bool IsActive { get; set; }

    [ForeignKey("product_id"), Column(name: "product_id")]
    public Product Product { get; set; } = new();
}