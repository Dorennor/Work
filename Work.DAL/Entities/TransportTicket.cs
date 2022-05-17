using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class TransportTicket
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("NumberOfUsing")]
    public int NumberOfUsing { get; set; }

    [Required]
    [Column("TransportId")]
    public int TransportId { get; set; }

    [Required]
    [Column("TransportPrice")]
    public double TransportPrice { get; set; }
}