using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models;

public class Villa
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public DateTime CreatedDate { get; set; }
    
}