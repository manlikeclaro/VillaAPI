namespace VillaAPI.Models.Dto;

public class VillaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public decimal Rate { get; set; }
    public int SquareFeet { get; set; }
    public int Occupancy { get; set; }
    public string ImgUrl { get; set; }
    public string Amenity { get; set; }
}