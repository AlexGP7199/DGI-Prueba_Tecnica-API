using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.TipoContribuyente;
using DGII.Application.Dtos.Response.TipoContribuyente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Interfaces
{
    public interface ITipoContribuyenteApplication
    {
        Task<BaseResponse<IEnumerable<TipoContribuyenteResponseDto>>> GetAllAsync();
        Task<BaseResponse<TipoContribuyenteResponseDto>> GetByIdAsync(int id);
        Task<BaseResponse<bool>> RegisterAsync(TipoContribuyenteAddRequestDto entity);
        Task<BaseResponse<bool>> EditAsync(int id,TipoContribuyenteModifyRequestDto entity);
        Task<BaseResponse<bool>> RemoveAsync(int id);
    }
}
