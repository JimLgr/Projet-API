using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMrTerenceAPI.Entities
{
    public class Fournisseur
    {
        public int fournisseurId { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string phone { get; set; }
        public object fax { get; set; }
        public string email { get; set; }
        public object website { get; set; }
    }
}
