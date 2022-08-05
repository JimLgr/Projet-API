using System.ComponentModel.DataAnnotations;

namespace MrTerenceWebAPI.DTO.Adresse
{
    public class AdresseAddDTO
    {
        [Required]
        public long AdresseId { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Rue { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        public int CodePostale { get; set; }

        [Required]
        public string Pays { get; set; }

        [Required]
        public long FournisseurId { get; set; }
    }
}
