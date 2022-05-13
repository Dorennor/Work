using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class Tour
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("TourName")]
    public string TourName { get; set; }

    [Required]
    [Column("TourType")]
    public string TourType { get; set; }

    [Required]
    [Column("TourRegion")]
    public string TourRegion { get; set; }

    [Required]
    [Column("TourMovementType")]
    public string TourMovementType { get; set; }

    [Required]
    [Column("Date")]
    public DateTime TourDateTime { get; set; }

    [Required]
    [Column("TourDurationInDays")]
    public int TourDurationInDays { get; set; }
}