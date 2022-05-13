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
    [Column("HotelStars")]
    public int HotelStars { get; set; }

    [Required]
    [Column("HotelPrice")]
    public double HotelPrice { get; set; }
}