﻿using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.Dto.Villa;

public class VillaCreateDto
{
    [Required] [MaxLength(30)] public string Name { get; set; }
    [Required] [MaxLength(100)] public string Details { get; set; }
    [Range(1, 10000)] public decimal Rate { get; set; }
    [Range(100, 10000)] public int SquareFeet { get; set; }
    [Range(1, 20)] public int Occupancy { get; set; }
    [Url] public string ImgUrl { get; set; }
    [MaxLength(100)] public string Amenity { get; set; }
}