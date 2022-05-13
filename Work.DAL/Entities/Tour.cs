using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class Tour
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("TourName")]
    public string Name { get; set; }

    [Required]
    [Column("TourType")]
    public string Type { get; set; }

    [Required]
    [Column("Region")]
    public string Region { get; set; }

    [Required]
    [Column("MovementType")]
    public string MovementType { get; set; }

    [Required]
    [Column("Date")]
    public DateTime TourDateTime { get; set; }

    [Required]
    [Column("Price")]
    public double Price { get; set; }

    [Required]
    [Column("TourDuration")]
    public int TourDuration { get; set; }
}