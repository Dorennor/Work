﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class TransportTicket
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("Date")]
    public DateTime DateTime { get; set; }

    [Required]
    [Column("NumberOfUsing")]
    public int NumberOfUsing { get; set; }

    [Required]
    [Column("Transport")]
    public int TransportId { get; set; }

    [ForeignKey("TransportId")]
    public Transport Transport { get; set; }

    [Required]
    [Column("TransportPrice")]
    public double TransportPrice { get; set; }
}