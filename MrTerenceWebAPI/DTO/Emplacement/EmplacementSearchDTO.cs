using System.ComponentModel.DataAnnotations;

namespace MrTerenceWebAPI.DTO.Emplacement
{
    public class EmplacementSearchDTO
    {
        [Range(2, 100)]
        public int Limit { get; set; } = 10;
    }
}
