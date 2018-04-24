using System;
using System.ComponentModel.DataAnnotations;

public class Staff
{
    [Required]
    [Key]
    public String Email { get; set; }


}