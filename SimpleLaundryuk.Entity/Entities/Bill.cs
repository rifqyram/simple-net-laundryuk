using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLaundryuk.Entity.Entities;

[Table(name: "t_bill")]
public class Bill : EntityBase
{
    [Column(name: "trans_date")]
    public DateTime TransDate { get; set; }
    
    [ForeignKey(name: "customer_id"), Column(name:"customer_id")]
    public Customer Customer { get; set; } = new();

    public ICollection<BillDetail>? BillDetails { get; set; }
}