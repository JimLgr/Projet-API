using System.ComponentModel.DataAnnotations;

namespace MrTerenceWebAPI.DTO.Fournisseur
{
    public class FournisseurAddDTO
    {
        [Required]
        public long FournisseurId { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public long AdresseId { get; set; }
    }
}
