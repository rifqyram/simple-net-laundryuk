using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLaundryuk.Entity.Entities;

[Table(name: "m_customer")]
public class Customer : EntityBase
{
    [Column(name: "name")] public string Name { get; set; } = string.Empty;
    [Column(name: "mobile_phone")] public string MobilePhone { get; set; } = string.Empty;
}