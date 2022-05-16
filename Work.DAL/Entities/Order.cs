using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("Tour")]
    public int TourId { get; set; }

    [ForeignKey("TourId")]
    public Tour Tour { get; set; }

    [Required]
    [Column("User")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [Column("HotelReservationTicket")]
    public int? HotelTicketReservationId { get; set; }

    [ForeignKey("UserId")]
    public HotelTicket? HotelReservationTicket { get; set; }

    [Column("TransportReservationTicket")]
    public int? TransportReservationId { get; set; }

    [ForeignKey("TransportId")]
    public TransportTicket? TransportReservationTicket { get; set; }

    [Required]
    [Column("FinalPrice")]
    public double FinalPrice { get; set; }
}