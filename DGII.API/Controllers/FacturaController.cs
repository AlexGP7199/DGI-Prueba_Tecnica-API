using DGII.Application.Dtos.Request.Facturas;
using DGII.Application.Interfaces;
using DGII.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGII.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaApplication _facturaApplication;
        public FacturaController(IFacturaApplication facturaApplication)
        {
            _facturaApplication = facturaApplication;
        }

        [HttpGet("ObtenerCantidadFacturasByContribuyenteId")]
        public async Task<IActionResult> CantidadFacturasContribuyentes(int contribuyenteId)
        {
            var response = await _facturaApplication.GetCantidadFacturasByContribuyenteId(contribuyenteId);
            return Ok(response);
        }


        [HttpGet("ObtenerTodasLasFacturasByContribyenteId")]
        public async Task<IActionResult> GetAllFacturasBy(int id, int pageNumber, int pageSize) 
        {
            var response = await _facturaApplication.getAllFacturasByRncCedulaId(id, pageNumber, pageSize);
            return Ok(response);
        }

        [HttpPost("CreateFactura")]
        public async Task<IActionResult> CreateFactura([FromBody] FacturaAddRequestDto _factura)
        {
            var response = await _facturaApplication.RegisterAsync(_factura);
            return Ok(response);
        }

        [HttpGet("ObtenerMontoTotalITBISbyContribuidorId")]
        public async Task<IActionResult> getMontoTotalITBISbyContribuidorID(int id)
        {
            var response = await _facturaApplication.GetMontoTotalItbisById(id);
            return Ok(response);
        }
    }
}
