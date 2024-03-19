using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.EstatusContribuyentes;
using DGII.Application.Dtos.Request.TipoContribuyente;
using DGII.Application.Dtos.Response.EstatusContribuyentes;
using DGII.Application.Dtos.Response.TipoContribuyente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Interfaces
{
    public interface IEstatusContribuyenteApplication
    {
        Task<BaseResponse<IEnumerable<EstatusContribuyenteResponseDto>>> GetAllAsync();
        Task<BaseResponse<EstatusContribuyenteResponseDto>> GetByIdAsync(int id);
        Task<BaseResponse<bool>> RegisterAsync(EstatusContribuyenteAddRequestDto entity);
        Task<BaseResponse<bool>> EditAsync(int id,EstatusContribuyenteModifyRequestDto entity);
        Task<BaseResponse<bool>> RemoveAsync(int id);
    }
}
