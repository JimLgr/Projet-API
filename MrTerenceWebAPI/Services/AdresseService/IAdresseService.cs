using MrTerenceWebAPI.DTO.Adresse;

namespace MrTerenceWebAPI.Services.AdresseService
{
    public interface IAdresseService
    {
        AdresseDetailsDTO LireUneAdresse(long id);
        bool AjouterAdresse(AdresseAddDTO dto);
        string SupprimerAdresse(long id);
        IEnumerable<AdresseIndexDTO> LireAdresse(AdresseSearchDTO dto);
    }
}
