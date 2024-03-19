using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.Contribuyentes;
using DGII.Application.Dtos.Response.Contribuyentes;
using DGII.Domain.Entities;
using DGII.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Interfaces
{
    public interface IContribuyenteApplication
    {
        Task<BaseResponse<CantidadContribuyentesResponse>> GetCantidadDeContribuyentes();
        Task<BaseResponse<List<ContribuyentePersonalInfoResponseDto>>> GetAllContribuyenteInfo(int pageNumber, int pageSize);
        Task<BaseResponse<ContribuyentePersonalInfoResponseDto>> GetAllContribuyenteInfoById(int id);
        Task<ContribuyentePersonalInfoResponseDto> GetContribuyenteByType(int tipoContribuyenteId);
        Task<ContribuyentePersonalInfoResponseDto> GetContribuyenteByEstatus(int estatusContribuyenteId);
        Task<ContribuyentePersonalInfoResponseDto> GetContribuyenteByRncCedula(string rncCedula);


        // genericas

        Task<ContribuyenteEditResponseDto> GetContribuyenteById(int id);
        Task<BaseResponse<bool>> RegisterContribuyente(ContribuyenteAddRequestDto _contribuyente);
        Task<BaseResponse<bool>> UpdateContribuyente(int id, ContribuyenteModifyRequestDto _contribuyente);
    
    }
}
