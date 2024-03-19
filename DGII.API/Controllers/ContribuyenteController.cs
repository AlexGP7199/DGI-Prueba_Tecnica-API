using DGII.Application.Dtos.Request.Contribuyentes;
using DGII.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DGII.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyenteApplication _contribuyenteApplication;
        public ContribuyenteController(IContribuyenteApplication contribuyenteApplication)
        {
            _contribuyenteApplication = contribuyenteApplication;
        }

        [HttpGet("ObtenerCantidadDeContribuyentes")]
        public async Task<IActionResult> CantidadContribuyentes()
        {
            var response = await _contribuyenteApplication.GetCantidadDeContribuyentes();
            return Ok(response);
        }

        [HttpGet("ObtenerContribuyentes")]
        public async Task<IActionResult> ListContribuyentes(int pageNumber, int pageSize)
        {
            var response = await _contribuyenteApplication.GetAllContribuyenteInfo(pageNumber, pageSize);
            return Ok(response);
        }

        [HttpGet("ObtenerContribuyenePorId")]
        public async Task<IActionResult> ContribuyenteById(int id)
        {
            var response = await _contribuyenteApplication.GetAllContribuyenteInfoById(id); 
            return Ok(response);
        }
        [HttpPost("CrearContribuyente")]
        public async Task<IActionResult> CreateContribuyente([FromBody] ContribuyenteAddRequestDto _contribuyente)
        {
            var response = await _contribuyenteApplication.RegisterContribuyente(_contribuyente);
            return Ok(response);
        }
        [HttpPut("ActualizarContribuyente")]
        public async Task<IActionResult> ContribuyenteUpdate([FromBody] ContribuyenteModifyRequestDto _contribuyente, int id)
        {
            var response = await _contribuyenteApplication.UpdateContribuyente(id, _contribuyente);
            return Ok(response);
        }
        /*
        [HttpGet("ObtenerContribuyenteConFacturasPorId")]
        public async Task<IActionResult> ListContribuyentesWithFacturas(int id)
        {
            var response = await _contribuyenteApplication.GetContribuyenteByIdWithFacturas(id);
            return Ok(response);
        } */
    }
}
