using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLaundryuk.Entity.Entities;

[Table(name: "t_bill_detail")]
public class BillDetail : EntityBase
{
    [ForeignKey(name: "bill_id"), Column(name: "bill_id")]
    public Bill Bill { get; set; } = new();

    [Column(name: "weight")] public int Weight { get; set; }

    [ForeignKey(name: "product_price_id"), Column(name: "product_price_id")]
    public ProductPrice ProductPrice { get; set; } = new();
}