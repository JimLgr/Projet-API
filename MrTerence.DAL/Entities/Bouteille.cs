using System;
using System.Collections.Generic;

namespace MrTerenceWebAPI.DAL.Entities
{
    public partial class Bouteille
    {
        public long BouteilleId { get; set; }
        public string Label { get; set; }
        public int Type { get; set; }
        public decimal Degree { get; set; }
        public decimal Volume { get; set; }
        public DateTime MiseEnBouteille { get; set; }
        public string Marque { get; set; } = null!;
        public string Origine { get; set; } = null!;
        public string Pays { get; set; } = null!;
        public bool Stock { get; set; }
        public string? Review { get; set; }
        public long FournisseurId { get; set; }
        public long EmplacementId { get; set; }

        public virtual Emplacement Emplacement { get; set; } = null!;
        public virtual Fournisseur Fournisseur { get; set; } = null!;
    }
}
