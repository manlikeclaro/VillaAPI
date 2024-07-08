using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.Dto;

public class VillaUpdateDto
{
    [Required] [MaxLength(30)] public string Name { get; set; }
    [Required] [MaxLength(50)] public string Details { get; set; }
    [Required] [Range(1, 10000)] public decimal Rate { get; set; }
    [Required] [Range(100, 10000)] public int SquareFeet { get; set; }
    [Required] [Range(1, 20)] public int Occupancy { get; set; }
    [Required] [Url] public string ImgUrl { get; set; }
    [MaxLength(100)] public string Amenity { get; set; }
}