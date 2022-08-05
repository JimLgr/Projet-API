using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMrTerenceAPI.Entities
{
    public class Bouteille
    {
        public int bouteilleId { get; set; }
        public string label { get; set; }
        public int type { get; set; }
        public string degreeAlcool { get; set; }
        public string volume { get; set; }
        public int anneeDeMiseEnBouteille { get; set; }
        public string marque { get; set; }
        public string origine { get; set; }
        public string pays { get; set; }
        public bool stock { get; set; }
        public object review { get; set; }
        public Emplacement emplacement { get; set; }
    }
}
