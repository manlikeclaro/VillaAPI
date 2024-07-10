using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.Dto.VillaNumber;

public class VillaNumberUpdateDto
{
    // public int VillaNo { get; set; }
    public string Details { get; set; }
    
    [Required] public int VillaId { get; set; }
}