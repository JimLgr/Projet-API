using System.ComponentModel.DataAnnotations;

namespace MrTerenceWebAPI.DTO.Fournisseur
{
    public class FournisseurSearchDTO
    {
        public string? Keyword { get; set; }

        public long AdresseId { get; set; }

        [Range(2, 100)]
        public int Limit { get; set; } = 10;
    }
}
