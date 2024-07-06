using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillaAPI.Models.Dto;

public class VillaDto
{
    // [Key] public int Id { get; set; }
    // [Required] [MaxLength(30)] public string Name { get; set; }
    // [Required] [MaxLength(50)] public string Location { get; set; }
    // [Range(1, 10)] public int? Bedrooms { get; set; }
    // [Range(1, 10)] public int? Bathrooms { get; set; }
    // [Range(50, 5000)] public decimal? PricePerNight { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required] [MaxLength(30)] 
    public string Name { get; set; }
    
    [Required] [MaxLength(50)] 
    public string Details { get; set; }
    
    [Range(1, 10000)] 
    public decimal Rate { get; set; }
    
    [Range(100, 10000)] 
    public int SquareFeet { get; set; }
    
    [Range(1, 20)] 
    public int Occupancy { get; set; }
    
    [Url] 
    public string ImgUrl { get; set; }
    
    [MaxLength(100)] 
    public string Amenity { get; set; }
}