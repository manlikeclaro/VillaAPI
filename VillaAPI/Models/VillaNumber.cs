using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillaAPI.Models;

public class VillaNumber
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int VillaNo { get; set; }
    public string Details { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}