using MrTerenceWebAPI.DAL;
using MrTerenceWebAPI.DAL.Entities;
using MrTerenceWebAPI.DTO.Fournisseur;

namespace MrTerenceWebAPI.Services.FournisseurService
{
    public class FournisseurService : IFournisseurService
    {
        private readonly GestionMrTerenceContext db = new GestionMrTerenceContext();


        public bool AjouterFournisseur(FournisseurAddDTO dto)
        {
            
            if (db.Adresses.FirstOrDefault(a => a.AdresseId == dto.AdresseId) == null)
            {
                return false;
            }
            Fournisseur fournisseur = new Fournisseur()
            {
                FournisseurId = dto.FournisseurId,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Phone = dto.Phone,
                Fax = dto.Fax,
                Email = dto.Email,
                Website = dto.Website,
                AdresseId = dto.AdresseId,
            };

            if (db.Fournisseurs.SingleOrDefault(f => f.Nom == dto.Nom && f.Prenom == dto.Prenom && f.Phone == dto.Phone) == null)
            {

                db.Fournisseurs.Add(fournisseur);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool SupprimerFournisseur(long id)
        //{

        //    Fournisseur fournisseur = db.Fournisseurs.FirstOrDefault(f => f.FournisseurId == id);
        //    if (fournisseur == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        db.Fournisseurs.Remove(fournisseur);
        //        db.SaveChanges();
        //        return true;
        //    }
        //}
        public FournisseurDetailsDTO LireUnFournisseur(long id)
        {
            Fournisseur? fournisseur = db.Fournisseurs.FirstOrDefault(f => f.FournisseurId == id);
            if (fournisseur == null)
            {
                return null;
            }
            return new FournisseurDetailsDTO
            {
                 FournisseurId = fournisseur.FournisseurId,
                 Nom = fournisseur.Nom,
                 Prenom = fournisseur.Prenom,
                 Phone = fournisseur.Phone,
                 Fax = fournisseur.Fax,
                 Email = fournisseur.Email,
                 Website = fournisseur.Website,
             };     
   
        }
        public IEnumerable<FournisseurIndexDTO> LireFournisseur(FournisseurSearchDTO dto)
        {
            return db.Fournisseurs.Where(f => dto.Keyword == null
                              || f.Nom.Contains(dto.Keyword)
                              || f.Prenom.Contains(dto.Keyword)
                              || f.Website.Contains(dto.Keyword))
                          .Where(f => dto.AdresseId == 0 || dto.AdresseId == f.AdresseId)
                          .Take(dto.Limit)
             .Select(f => new FournisseurIndexDTO
             {
                 FournisseurId = f.FournisseurId,
                 Nom = f.Nom,
                 Prenom = f.Prenom,
                 Phone = f.Phone,
                 Email = f.Email,
                 Fax = f.Fax,
                 Website = f.Website,
                 AdresseId = dto.AdresseId,
             });

        }
    }
}
