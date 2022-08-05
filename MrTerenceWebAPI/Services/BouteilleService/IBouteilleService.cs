using CaveVinsMrTerence.Controllers;
using CaveVinsMrTerence.DTO.Bouteille;
using MrTerenceWebAPI.DAL.Entities;
using MrTerenceWebAPI.DTO.Bouteille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveVinsMrTerence.Services
{
    public interface IBouteilleService
    {

        bool AjouterBouteille(BouteilleAddDTO dto);

        bool UpdateStockBouteille(long id);

        //bool SupprimerBouteille(long id);

        IEnumerable<BouteilleIndexDTO> LireBouteille(BouteilleSearchDTO dto);

        BouteilleDetailsDTO LireUneBouteille(long id);
    }
}
