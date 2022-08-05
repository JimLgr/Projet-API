using System.ComponentModel.DataAnnotations;

namespace MrTerenceWebAPI.DTO.Bouteille
{
    public class UpdateStockBouteilleDTO
    {
        [Required]
        public bool Stock { get; set; }
    }
}
