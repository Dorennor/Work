using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("TourId")]
    public int TourId { get; set; }

    [Required]
    [Column("UserId")]
    public int UserId { get; set; }

    [Required]
    [Column("HotelTicketId")]
    public int HotelTicketId { get; set; }

    [Required]
    [Column("TransportTicketId")]
    public int TransportTicketId { get; set; }

    [Required]
    [Column("FinalPrice")]
    public double FinalPrice { get; set; }
}