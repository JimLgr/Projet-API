using CaveVinsMrTerence.DTO.Bouteille;
using CaveVinsMrTerence.Services;
using Microsoft.AspNetCore.Mvc;
using MrTerenceWebAPI.DAL.Entities;
using MrTerenceWebAPI.DTO.Bouteille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CaveVinsMrTerence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BouteilleController : ControllerBase
    {
        private readonly IBouteilleService _bouteilleService;

        public BouteilleController(IBouteilleService bouteilleService)
        {
            _bouteilleService = bouteilleService;
        }

        [HttpGet("/GetBouteille")]
        [Produces(typeof(IEnumerable<BouteilleIndexDTO>))]

        public IActionResult Index([FromQuery] BouteilleSearchDTO dto)
        {
            IEnumerable<BouteilleIndexDTO> value = _bouteilleService.LireBouteille(dto);
            return base.Ok(value);
        }

        [HttpPost("/AddBouteille")]
        [Produces(typeof(int))]
        public IActionResult Create([FromBody] BouteilleAddDTO dto)
        {
            bool response = _bouteilleService.AjouterBouteille(dto);
            return Ok(response);
        }

        [HttpPatch("{id}/stock")]
        public IActionResult UpdateStock([FromRoute] int id)
        {
            try
            {
                if (!_bouteilleService.UpdateStockBouteille(id))
                {
                    return NotFound();
                }
            }
            catch (ArgumentException)
            {
                return BadRequest("Cette id n'existe pas");
            }
            return NoContent();

        }

        //[HttpDelete("{id}/DeleteBouteille")]
        //public IActionResult Delete([FromRoute] long id)
        //{
        //    if (!_bouteilleService.SupprimerBouteille(id))
        //    {
        //        return NotFound();
        //    }
        //    bool response = _bouteilleService.SupprimerBouteille(id);
        //    return Ok(response);
        //}

        [HttpGet("{id}")]
        [Produces(typeof(BouteilleDetailsDTO))]
        public IActionResult Find([FromRoute] long id)
        {

            BouteilleDetailsDTO bouteille = _bouteilleService.LireUneBouteille(id);
            if (bouteille is null)
            {

                return NotFound();
            }

            return Ok(bouteille);
        }

    }
}
