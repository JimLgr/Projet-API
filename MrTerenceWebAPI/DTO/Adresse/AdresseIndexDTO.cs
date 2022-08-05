using MrTerenceWebAPI.DAL.Entities;

namespace MrTerenceWebAPI.DTO.Adresse
{
    public class AdresseIndexDTO
    {
        public long AdresseId { get; set; }
        public int Numero { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public int CodePostale { get; set; }
        public string Pays { get; set; }
    }
}
