using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.EstatusContribuyentes;
using DGII.Application.Dtos.Request.Facturas;
using DGII.Application.Dtos.Response;
using DGII.Application.Dtos.Response.EstatusContribuyentes;
using DGII.Application.Dtos.Response.Facturas;
using DGII.Domain.Entities;
using DGII.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Interfaces
{
    public interface IFacturaApplication
    {
        Task<BaseResponse<CantidadFacturasResponse>> GetCantidadFacturasByContribuyenteId(int contribuyenteId);
        Task<BaseResponse<IEnumerable<FacturasResponseDto>>> GetAllAsync();
        Task<BaseResponse<List<FacturasResponseDto>>> getAllFacturasByRncCedulaId(int rncCedulaId, int pageNumber, int pageSize);
        Task<BaseResponse<FacturaMontoTotalResponseDto>> GetMontoTotalItbisById(int id);
        Task<BaseResponse<FacturasResponseDto>> GetByIdAsync(int id);
        Task<BaseResponse<bool>> RegisterAsync(FacturaAddRequestDto entity);
        Task<BaseResponse<bool>> EditAsync(FacturaModifyRequestDto entity);
        //Task<FacturasResponseDto> valitedFacturaByRncCedula(string rncCedula)


    }
}
