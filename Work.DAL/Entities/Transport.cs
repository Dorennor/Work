using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class Transport
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("TransportName")]
    public string Name { get; set; }

    [Required]
    [Column("TransportPrice")]
    public double TransportPrice { get; set; }
}