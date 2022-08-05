using Microsoft.AspNetCore.Mvc;
using MrTerenceWebAPI.DTO.Adresse;
using MrTerenceWebAPI.Services.AdresseService;
using Microsoft.AspNetCore.Http;

namespace MrTerenceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : ControllerBase
    {
        private readonly IAdresseService _adresseService;

        public AdresseController(IAdresseService adresseService)
        {
            _adresseService = adresseService;
        }

        [HttpGet("/GetAdresse")]
        [Produces(typeof(IEnumerable<AdresseIndexDTO>))]
        public IActionResult IndexAdresse([FromQuery] AdresseSearchDTO dto)
        {
            IEnumerable<AdresseIndexDTO> value = _adresseService.LireAdresse(dto);
            return base.Ok(value);
        }

        [HttpPost("/AddAdresse")]
        [Produces(typeof(int))]
        public IActionResult CreateAdresse([FromBody] AdresseAddDTO dto)
        {
            bool response = _adresseService.AjouterAdresse(dto);
            return Ok(response);
        }

        [HttpDelete("{id}/DeleteAdresse")]
        public IActionResult DeleteAdresse([FromRoute] long id)
        {
            string response = _adresseService.SupprimerAdresse(id);
            if (response != null)
            {
                return Ok(response);
            } 
            return NotFound();
        }

        [HttpGet("{id}")]
        [Produces(typeof(AdresseDetailsDTO))]
        public IActionResult Find([FromRoute] long id)
        {

            AdresseDetailsDTO adresse = _adresseService.LireUneAdresse(id);
            if (adresse is null)
            {

                return NotFound();
            }

            return Ok(adresse);
        }
    }
}
