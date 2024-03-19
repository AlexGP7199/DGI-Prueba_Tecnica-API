using AutoMapper;
using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.Nfs;
using DGII.Application.Dtos.Response.Contribuyentes;
using DGII.Application.Dtos.Response.NFCs;
using DGII.Application.Interfaces;
using DGII.Domain.Entities;
using DGII.Infrastructure.Persistence.Interfaces;
using DGII.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Services
{
    public class NcfApplication : INCFsApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NcfApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool>EditAsync(Ncf _ncfs)
        {
            var data = await _unitOfWork.ncfs.EditAsync(_ncfs);
            if(data == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<BaseResponse<NCFResponseDto>> getContrubuyenteNFCinfoById(int contribuyenteId)
        {
            var response = new BaseResponse<NCFResponseDto>();
            var data = await _unitOfWork.ncfs.getContrubuyenteNFCinfoById(contribuyenteId);
            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<NCFResponseDto>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<NCFResponseDto> getContrubuyenteNFCinfoByIdContribuyente(int contribuyenteId)
        {
            var data = await _unitOfWork.ncfs.getContrubuyenteNFCinfoById(contribuyenteId);
            return _mapper.Map<NCFResponseDto>(data);
        }

    
    }
}
