using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class HotelTicket
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("NumberOfDays")]
    public int NumberOfDays { get; set; }

    [Required]
    [Column("HotelId")]
    public int HotelId { get; set; }

    [Required]
    [Column("SummaryPrice")]
    public double SummaryPrice { get; set; }
}