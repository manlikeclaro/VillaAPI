using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.Dto.VillaNumber;

public class VillaNumberDto
{
    public int VillaNo { get; set; }
    public string Details { get; set; }

    [Required] public int VillaId { get; set; }
}