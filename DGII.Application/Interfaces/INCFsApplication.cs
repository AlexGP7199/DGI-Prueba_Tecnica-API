using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.Nfs;
using DGII.Application.Dtos.Response.NFCs;
using DGII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Interfaces
{
    public interface INCFsApplication
    {
        Task<BaseResponse<NCFResponseDto>> getContrubuyenteNFCinfoById(int contribuyenteId);
        Task<NCFResponseDto>getContrubuyenteNFCinfoByIdContribuyente(int contribuyenteId);
        Task<bool> EditAsync(Ncf _ncfs);
    }
}
