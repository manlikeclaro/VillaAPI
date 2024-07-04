using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.Dto;

public class VillaDto
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(30)] public string Name { get; set; }
    [Required] [MaxLength(50)] public string Location { get; set; }
    [Range(1, 10)] public int Bedrooms { get; set; }
    [Range(1, 10)] public int Bathrooms { get; set; }
    [Range(50, 5000)] public decimal PricePerNight { get; set; }
}