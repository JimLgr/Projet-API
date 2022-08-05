using Microsoft.AspNetCore.Mvc;
using MrTerenceWebAPI.DTO.Emplacement;
using MrTerenceWebAPI.Services.EmplacementService;
using Microsoft.AspNetCore.Http;

namespace MrTerenceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmplacementController : ControllerBase
    {
        private readonly IEmplacementService _emplacementService;

        public EmplacementController(IEmplacementService emplacementService)
        {
            _emplacementService = emplacementService;
        }
        [HttpGet("/GetEmplacement")]
        [Produces(typeof(IEnumerable<EmplacementIndexDTO>))]
        public IActionResult Index([FromQuery] EmplacementSearchDTO dto)
        {
            IEnumerable<EmplacementIndexDTO> value = _emplacementService.LireEmplacement(dto);
            return base.Ok(value);
        }

        [HttpPost("/AddEmplacement")]
        [Produces(typeof(int))]
        public IActionResult CreateEmplacement([FromBody] EmplacementAddDTO dto)
        {
            bool response = _emplacementService.AjouterEmplacement(dto);
            return Ok(response);
        }

        [HttpDelete("{id}/DeleteEmplacement")]
        public IActionResult DeleteEmplacement([FromRoute] long id)
        {
            string response = _emplacementService.SupprimerEmplacement(id);
            if (response == null)
            {
                return NotFound();     
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Produces(typeof(EmplacementDetailsDTO))]
        public IActionResult Find([FromRoute] long id)
        {

            EmplacementDetailsDTO emplacement = _emplacementService.LireUnEmplacement(id);
            if (emplacement is null)
            {

                return NotFound();
            }

            return Ok(emplacement);
        }
    }
}
