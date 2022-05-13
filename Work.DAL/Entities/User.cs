using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.DAL.Entities;

public class User : IdentityUser
{
    [Key]
    [Required]
    [Column("Id")]
    public int Id { get; set; }


    //[Required]
    //[Column("Email")]
    //public string Email { get; set; }

    //[Required]
    //[Column("FirstName")]
    //public string FirstName { get; set; }

    //[Required]
    //[Column("LastName")]
    //public string LastName { get; set; }

    //[Required]
    //[Column("Password")]
    //public string Password { get; set; }

    //[Required]
    //[Column("UserRole")]
    //public string? UserRole { get; set; }
}