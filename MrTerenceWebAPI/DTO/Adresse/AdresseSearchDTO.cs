using System.ComponentModel.DataAnnotations;

namespace MrTerenceWebAPI.DTO.Adresse
{
    public class AdresseSearchDTO
    {
        public string? Keyword { get; set; }

        public long? FournisseurId { get; set; }

        [Range(2, 100)]
        public int Limit { get; set; } = 10;
    }
}
