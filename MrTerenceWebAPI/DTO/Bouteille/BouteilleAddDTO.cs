using CaveVinsMrTerence.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MrTerenceWebAPI.DAL.Entities;

namespace CaveVinsMrTerence.DTO.Bouteille
{
    public class BouteilleAddDTO
    {
        public long BouteilleId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Label { get; set; }

        [Required]
        [Range(0, 3)]
        public int Type { get; set; }

        [Required]
        public decimal DegreeAlcool { get; set; }

        [Required]
        public decimal Volume { get; set; }

        [NotAfterToday]
        public DateTime MiseEnBouteille { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Marque { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Origine { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Pays { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string? Review { get; set; }

        [Required]
        public bool Stock { get; set; }

        [Required]
        public long FournisseurId { get; set; }

        [Required]
        public long EmplacementId { get; set; }
        
    }
}
