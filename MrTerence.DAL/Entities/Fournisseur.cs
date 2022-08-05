using System;
using System.Collections.Generic;

namespace MrTerenceWebAPI.DAL.Entities
{
    public partial class Fournisseur
    {
        public Fournisseur()
        {
            Adresses = new HashSet<Adresse>();
        }

        public long FournisseurId { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public long? AdresseId { get; set; }

        public virtual Adresse? Adresse { get; set; }
        public virtual ICollection<Adresse> Adresses { get; set; }
    }
}
