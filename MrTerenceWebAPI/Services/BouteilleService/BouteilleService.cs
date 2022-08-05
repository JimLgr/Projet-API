using CaveVinsMrTerence.Controllers;
using CaveVinsMrTerence.DTO.Bouteille;
using MrTerenceWebAPI.DAL;
using MrTerenceWebAPI.DAL.Entities;
using MrTerenceWebAPI.DTO.Bouteille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveVinsMrTerence.Services
{
    public class BouteilleService : IBouteilleService
    {

        private readonly GestionMrTerenceContext db = new GestionMrTerenceContext();


        public bool AjouterBouteille(BouteilleAddDTO dto)
        {
            if (db.Fournisseurs.FirstOrDefault(f => f.FournisseurId == dto.FournisseurId) == null)
            {
                return false;
            }
            if (db.Emplacements.FirstOrDefault(e => e.EmplacementId == dto.EmplacementId) == null)
            {
                return false;
            }
            Bouteille bouteille = new Bouteille()
            {
                BouteilleId = dto.BouteilleId,
                Label = dto.Label,
                Type = (int)dto.Type,
                MiseEnBouteille = dto.MiseEnBouteille,
                Degree = dto.DegreeAlcool,
                Volume = dto.Volume,
                Pays = dto.Pays,
                Marque = dto.Marque,
                Origine = dto.Origine,
                Review = dto.Review,
                EmplacementId = dto.EmplacementId,
                FournisseurId = dto.FournisseurId,
            };

            if (db.Bouteilles.SingleOrDefault(s => s.Label == dto.Label && s.Marque == dto.Marque && s.Origine == dto.Origine) == null)
            {

                db.Bouteilles.Add(bouteille);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool SupprimerBouteille(long id)
        //{

        //    Bouteille bouteille = db.Bouteilles.FirstOrDefault(b => b.BouteilleId == id);
        //    if (db.Bouteilles.SingleOrDefault(bouteille => bouteille.BouteilleId == id) == null)
        //    {
        //        return false;
        //    }
        //    else
        //    { 
        //        db.Bouteilles.Remove(bouteille);
        //        db.SaveChanges();
        //        return true;
        //    }
        //}

        public BouteilleDetailsDTO LireUneBouteille(long id)
        {
            Bouteille? b = db.Bouteilles.FirstOrDefault(b => b.BouteilleId == id);
            if (b == null)
            {
                return null;
            }
            return new BouteilleDetailsDTO
            {
                BouteilleId = b.BouteilleId,
                Label = b.Label,
                Type = b.Type,
                DegreeAlcool = b.Degree.ToString() + "%",
                Volume = b.Volume.ToString() + "L",
                AnneeDeMiseEnBouteille = b.MiseEnBouteille.Year,
                Marque = b.Marque,
                Pays = b.Pays,
                Origine = b.Origine,
                Stock = b.Stock,
            };
        }
        public bool UpdateStockBouteille(long id)
        {
            Bouteille? bouteille = db.Bouteilles.FirstOrDefault(b => b.BouteilleId == id);
            if (bouteille?.Stock == true)
            {
                bouteille.Stock = false;
                db.Bouteilles.UpdateRange(bouteille);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<BouteilleIndexDTO> LireBouteille(BouteilleSearchDTO dto)
        {
           return db.Bouteilles.Where(b => dto.Keyword == null
                             || b.Label.Contains(dto.Keyword)
                             || b.Origine.Contains(dto.Keyword)
                             || b.Marque.Contains(dto.Keyword)
                             || b.Pays.Contains(dto.Keyword))
                         .Where(b => dto.AnneeMiseEnBouteille == 0 || dto.AnneeMiseEnBouteille == b.MiseEnBouteille.Year)
                         .Take(dto.Limit)
            .Select(b => new BouteilleIndexDTO
            {
                BouteilleId = b.BouteilleId,
                Label = b.Label,
                Type = b.Type,
                AnneeDeMiseEnBouteille = b.MiseEnBouteille.Year,
                DegreeAlcool = b.Degree.ToString() + "%",
                Volume = b.Volume.ToString() + "L",
                Origine = b.Origine,
                Marque = b.Marque,
                Pays = b.Pays,
                Stock = b.Stock,
                Review = b.Review,
                Emplacement = b.Emplacement,
            });
       
        }


    }
}
