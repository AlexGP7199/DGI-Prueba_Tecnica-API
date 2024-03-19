using DGII.Application.Dtos.Request.Contribuyentes;
using DGII.Application.Dtos.Request.EstatusContribuyentes;
using DGII.Application.Interfaces;
using DGII.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DGII.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusContribuyenteController : ControllerBase
    {
        private readonly IEstatusContribuyenteApplication _estatusContribuyenteApplication;
        public EstatusContribuyenteController(IEstatusContribuyenteApplication estatusContribuyenteApplication)
        {
            _estatusContribuyenteApplication = estatusContribuyenteApplication;
        }

        [HttpGet("ObtenerTodosLosEstados")]
        public async Task<IActionResult> ListEstados()
        {
            var response = await _estatusContribuyenteApplication.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("ObtenerEstadoPorId")]
        public async Task<IActionResult> EstadoById(int id)
        {
            var response = await _estatusContribuyenteApplication.GetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost("CrearEstado")]
        public async Task<IActionResult> CreateEstado([FromBody] EstatusContribuyenteAddRequestDto _estado)
        {
            var response = await _estatusContribuyenteApplication.RegisterAsync(_estado);
            return Ok(response);
        }
        [HttpPut("ActualizarEstado")]
        public async Task<IActionResult> UpdateEstado([FromBody] EstatusContribuyenteModifyRequestDto _contribuyente, int id)
        {
            var response = await _estatusContribuyenteApplication.EditAsync(id, _contribuyente);
            return Ok(response);
        }


        [HttpDelete("EliminarEstado")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var response = await _estatusContribuyenteApplication.RemoveAsync(id);
            return Ok(response);
        }
    }
}
