using MrTerenceWebAPI.DAL;
using MrTerenceWebAPI.DAL.Entities;
using MrTerenceWebAPI.DTO.Adresse;

namespace MrTerenceWebAPI.Services.AdresseService
{
    public class AdresseService : IAdresseService
    {

        private readonly GestionMrTerenceContext db = new();

        public bool AjouterAdresse(AdresseAddDTO dto)
        {
            if (db.Fournisseurs.FirstOrDefault(f => f.FournisseurId == dto.FournisseurId) == null)
            {
                return false; 
            }
            Adresse adresse = new()
            {
                FournisseurId = dto.FournisseurId,
                AdresseId = dto.AdresseId,
                Rue = dto.Rue,
                Numero = dto.Numero,
                Ville = dto.Ville,
                Pays = dto.Pays,
                CodePostale = dto.CodePostale,        
            };

            if (db.Adresses.SingleOrDefault(a => a.Numero == dto.Numero && a.Ville == dto.Ville && a.Pays == dto.Pays && a.CodePostale == dto.CodePostale) == null)
            {
                db.Adresses.Add(adresse);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public string SupprimerAdresse(long id)
        {

            Adresse? adresse = db.Adresses.FirstOrDefault(a => a.AdresseId == id);
            if (adresse == null)
            {
                return $"Cette adresse ne peu pas être supprimer car elle n'existe pas";
            }
            else
            {
                db.Adresses.Remove(adresse);
                db.SaveChanges();
                return $"Cette adresse à bien été supprimer";
            }
        }

        public AdresseDetailsDTO LireUneAdresse(long id)
        {
            Adresse? adresse = db.Adresses.FirstOrDefault(a => a.AdresseId == id);
            if (adresse == null)
            {
                return null;
            }
            return new AdresseDetailsDTO
            {
                AdresseId = adresse.AdresseId,
                Rue = adresse.Rue,
                Numero = adresse.Numero,
                Ville = adresse.Ville,
                CodePostale = adresse.CodePostale,
                Pays = adresse.Pays,
            };
        }
        public IEnumerable<AdresseIndexDTO> LireAdresse(AdresseSearchDTO dto)
        {
            return db.Adresses.Where(a => dto.Keyword == null
                              || a.Rue.Contains(dto.Keyword)
                              || a.Ville.Contains(dto.Keyword)
                              || a.Pays.Contains(dto.Keyword))
                          .Where(a => a.FournisseurId == dto.FournisseurId || dto.FournisseurId == null)
                          .Take(dto.Limit)
             .Select(a => new AdresseIndexDTO
             {
                 AdresseId = a.AdresseId,
                 Rue = a.Rue,
                 Numero = a.Numero,
                 CodePostale = a.CodePostale,
                 Ville = a.Ville,
                 Pays = a.Pays, 
             });

        }


    }   
    
}
