using System;
using System.Collections.Generic;

namespace MrTerenceWebAPI.DAL.Entities
{
    public partial class Emplacement
    {
        public long EmplacementId { get; set; }
        public string Casier { get; set; } = null!;
        public string Etagere { get; set; } = null!;
    }
}
