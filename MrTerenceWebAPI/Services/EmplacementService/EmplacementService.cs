using MrTerenceWebAPI.DAL;
using MrTerenceWebAPI.DAL.Entities;
using MrTerenceWebAPI.DTO.Emplacement;

namespace MrTerenceWebAPI.Services.EmplacementService
{
    public class EmplacementService : IEmplacementService
    {
        private readonly GestionMrTerenceContext db = new GestionMrTerenceContext();

        public bool AjouterEmplacement(EmplacementAddDTO dto)
        {
            if (db.Emplacements.SingleOrDefault(e => e.Casier == dto.Casier && e.Etagere == dto.Etagere) == null)
            {
                Emplacement emplacement = new Emplacement()
                {
                    EmplacementId = dto.EmplacementId,
                    Casier = dto.Casier,
                    Etagere = dto.Etagere,

                };

                db.Emplacements.Add(emplacement);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string SupprimerEmplacement(long id)
        {

            Emplacement emplacement = db.Emplacements.FirstOrDefault(e => e.EmplacementId == id);
            if (emplacement == null)
            {
                return $"Cette Emplacement ne peu pas être supprimer car il n'existe pas";
            }
            db.Emplacements.Remove(emplacement);
            db.SaveChanges();
            return $"Cette Emplacement à bien été supprimer";
            
        }

        public EmplacementDetailsDTO LireUnEmplacement(long id)
        {
            Emplacement emplacement = db.Emplacements.FirstOrDefault(e => e.EmplacementId == id);
            if (emplacement == null)
            {
                return null;
            }
            return new EmplacementDetailsDTO
            {
                EmplacementId = emplacement.EmplacementId,
                Casier = emplacement.Casier,
                Etagere = emplacement.Etagere,
            };
        }

        public IEnumerable<EmplacementIndexDTO> LireEmplacement(EmplacementSearchDTO dto)
        {
            return db.Emplacements
                                  .Take(dto.Limit)
                                  .Select(e => new EmplacementIndexDTO
                                  {
                                      EmplacementId =e.EmplacementId,
                                      Casier = e.Casier,
                                      Etagere = e.Etagere,
                                  });

        }
    }
}
