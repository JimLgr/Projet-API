using System;
using System.Collections.Generic;

namespace MrTerenceWebAPI.DAL.Entities
{
    public partial class Adresse
    {
        public Adresse()
        {
            Fournisseurs = new HashSet<Fournisseur>();
        }

        public long AdresseId { get; set; }
        public int Numero { get; set; }
        public string Rue { get; set; } = null!;
        public string Ville { get; set; } = null!;
        public int CodePostale { get; set; }
        public string Pays { get; set; } = null!;
        public long FournisseurId { get; set; }

        public virtual Fournisseur Fournisseur { get; set; } = null!;
        public virtual ICollection<Fournisseur> Fournisseurs { get; set; }
    }
}
