using Microsoft.AspNetCore.Mvc;
using MrTerenceWebAPI.DTO.Fournisseur;
using MrTerenceWebAPI.Services.FournisseurService;
using Microsoft.AspNetCore.Http;

namespace MrTerenceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        

        private readonly IFournisseurService _fournisseurService;

        public FournisseurController(IFournisseurService fournisseurService)
        {
            _fournisseurService = fournisseurService;
        }

        [HttpGet("/GetFournisseur")]
        [Produces(typeof(IEnumerable<FournisseurIndexDTO>))]
        public IActionResult IndexFournisseur([FromQuery] FournisseurSearchDTO dto)
        {
            IEnumerable<FournisseurIndexDTO> value = _fournisseurService.LireFournisseur(dto);
            return base.Ok(value);
        }

        [HttpPost("/AddFournisseur")]
        [Produces(typeof(int))]
        public IActionResult CreateFournisseur([FromBody] FournisseurAddDTO dto)
        {
            bool response = _fournisseurService.AjouterFournisseur(dto);
            return Ok(response);
        }

        //[HttpDelete("{id}/DeleteFournisseur")]
        //public IActionResult DeleteFournisseur([FromRoute] long id)
        //{
        //    if (!_fournisseurService.SupprimerFournisseur(id))
        //    {
        //        return NotFound();
        //    }
        //    bool response = _fournisseurService.SupprimerFournisseur(id);
        //    return Ok(response);
        //}

        [HttpGet("{id}")]
        [Produces(typeof(FournisseurDetailsDTO))]
        public IActionResult Find([FromRoute] long id)
        {

            FournisseurDetailsDTO fournisseur = _fournisseurService.LireUnFournisseur(id);
            if (fournisseur is null)
            {

                return NotFound();
            }

            return Ok(fournisseur);
        }
    }
}
