using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLaundryuk.Entity.Entities;

public class EntityBase
{
    [Column(name: "id")] public Guid Id { get; set; }
    [Column(name: "created_at")] public DateTime CreatedAt { get; set; }
    [Column(name: "updated_at")] public DateTime UpdatedAt { get; set; }
}