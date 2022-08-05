using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMrTerenceAPI.Entities
{
    public class Emplacement
    {
        public long EmplacementId { get; set; }
        public string Casier { get; set; } = null!;
        public string Etagere { get; set; } = null!;
    }
}
