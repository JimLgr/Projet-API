using MrTerenceWebAPI.DAL.Entities;

namespace CaveVinsMrTerence.DTO.Bouteille
{
    public class BouteilleIndexDTO
    {
        public long BouteilleId { get; set; }
        public string Label { get; set; }
        public int Type { get; set; }
        public string DegreeAlcool { get; set; }
        public string Volume { get; set; }
        public int AnneeDeMiseEnBouteille { get; set; }
        public string Marque { get; set; }
        public string Origine { get; set; }
        public string Pays { get; set; }
        public bool Stock { get; set; }
        public string? Review { get; set; }
        public Emplacement Emplacement { get; set; }

    }
}
