using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class HotelTicket
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("Date")]
    public DateTime DateTime { get; set; }

    [Required]
    [Column("Hotel")]
    public int HotelId { get; set; }

    [ForeignKey("HotelId")]
    public Hotel Hotel { get; set; }

    [Required]
    [Column("Price")]
    public double Price { get; set; }
}