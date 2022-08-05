using MrTerenceWebAPI.DTO.Fournisseur;

namespace MrTerenceWebAPI.Services.FournisseurService
{
    public interface IFournisseurService
    {
        bool AjouterFournisseur(FournisseurAddDTO dto);

        //bool SupprimerFournisseur(long id);

        IEnumerable<FournisseurIndexDTO> LireFournisseur(FournisseurSearchDTO dto);

        FournisseurDetailsDTO LireUnFournisseur(long id);
    }
}
