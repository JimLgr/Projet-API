using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMrTerenceAPI.Entities
{
    public class Adresse
    {
        public long AdresseId { get; set; }
        public int Numero { get; set; }
        public string Rue { get; set; } = null!;
        public string Ville { get; set; } = null!;
        public int CodePostale { get; set; }
        public string Pays { get; set; } = null!;
        public long FournisseurId { get; set; }

        public override string ToString()
        {
            return $"{AdresseId} \n {Numero} \n {Rue} \n {Ville} \n {CodePostale} \n {Pays} \n {FournisseurId}";
        }
    }
}
