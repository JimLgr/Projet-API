
using MrTerenceWebAPI.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace CaveVinsMrTerence.DTO.Bouteille
{
    public class BouteilleSearchDTO
    {
        public string? Keyword { get; set; }

        public int AnneeMiseEnBouteille { get; set; }

        [Range(2, 100)]
        public int Limit { get;  set; } = 10;
    }
}
