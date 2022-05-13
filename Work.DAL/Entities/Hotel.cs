using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class Hotel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("HotelName")]
    public string HotelName { get; set; }

    [Required]
    [Column("Stars")]
    public int HotelStars { get; set; }

    [Required]
    [Column("Price")]
    public double Price { get; set; }
}