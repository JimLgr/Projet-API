using MrTerenceWebAPI.DTO.Emplacement;

namespace MrTerenceWebAPI.Services.EmplacementService
{
    public interface IEmplacementService
    {
         bool AjouterEmplacement(EmplacementAddDTO dto);
         string SupprimerEmplacement(long id);
         EmplacementDetailsDTO LireUnEmplacement(long id);
        IEnumerable<EmplacementIndexDTO> LireEmplacement(EmplacementSearchDTO dto);
    }
}
