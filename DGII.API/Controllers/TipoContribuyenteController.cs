using DGII.Application.Dtos.Request.EstatusContribuyentes;
using DGII.Application.Dtos.Request.TipoContribuyente;
using DGII.Application.Interfaces;
using DGII.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGII.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContribuyenteController : ControllerBase
    {
        private readonly ITipoContribuyenteApplication _tipoContribuyenteApplication;
        public TipoContribuyenteController(ITipoContribuyenteApplication tipoContribuyenteApplication)
        {
            _tipoContribuyenteApplication = tipoContribuyenteApplication;
        }

        [HttpGet("ObtenerTodosLosTipos")]
        public async Task<IActionResult> ListEstados()
        {
            var response = await _tipoContribuyenteApplication.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("ObtenerTipoPorId")]
        public async Task<IActionResult> EstadoById(int id)
        {
            var response = await _tipoContribuyenteApplication.GetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost("CrearTipo")]
        public async Task<IActionResult> CreateTipo([FromBody] TipoContribuyenteAddRequestDto _tipo)
        {
            var response = await _tipoContribuyenteApplication.RegisterAsync(_tipo);
            return Ok(response);
        }
        [HttpPut("ActualizarTipo")]
        public async Task<IActionResult> UpdateEstado([FromBody] TipoContribuyenteModifyRequestDto _tipo, int id)
        {
            var response = await _tipoContribuyenteApplication.EditAsync(id, _tipo);
            return Ok(response);
        }
        [HttpDelete("EliminarTipo")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var response = await _tipoContribuyenteApplication.RemoveAsync(id);
            return Ok(response);
        }
    }
}
