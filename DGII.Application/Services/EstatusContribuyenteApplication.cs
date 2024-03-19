using AutoMapper;
using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.EstatusContribuyentes;
using DGII.Application.Dtos.Response.EstatusContribuyentes;
using DGII.Application.Dtos.Response.TipoContribuyente;
using DGII.Application.Interfaces;
using DGII.Application.Validators.Contribuyente;
using DGII.Application.Validators.EstatusContribuyentes;
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
    public class EstatusContribuyenteApplication : IEstatusContribuyenteApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly EstatusContribuyentesValidators _validations;
        public EstatusContribuyenteApplication(IUnitOfWork unitOfWork, IMapper mapper, EstatusContribuyentesValidators validations)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validations = validations;
        }
        public async Task<BaseResponse<IEnumerable<EstatusContribuyenteResponseDto>>> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<EstatusContribuyenteResponseDto>>();
            var data = await _unitOfWork.estatusContribuyente.GetAllAsync();

            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<IEnumerable<EstatusContribuyenteResponseDto>>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<EstatusContribuyenteResponseDto>> GetByIdAsync(int id)
        {
            var response = new BaseResponse<EstatusContribuyenteResponseDto>();
            var data = await _unitOfWork.estatusContribuyente.GetByIdAsync(id);

            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<EstatusContribuyenteResponseDto>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

       
        public async Task<BaseResponse<bool>> RegisterAsync(EstatusContribuyenteAddRequestDto entity)
        {
            var response = new BaseResponse<bool>();
            var validatonResult = await _validations.ValidateAsync(entity);
            if (!validatonResult.IsValid)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validatonResult.Errors;
                return response;
            }
            var estatus = _mapper.Map<EstatusContribuyente>(entity);
            response.Data = await _unitOfWork.estatusContribuyente.RegisterAsync(estatus);
            if (response.Data == true)
            {
                response.isSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
                return response;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> EditAsync(int id,EstatusContribuyenteModifyRequestDto entity)
        {
            var response = new BaseResponse<bool>();
            //var validationResult = await _validations.ValidateAsync(_contribuyente);
            var estatusValue = await GetByIdAsync(id);
            if (estatusValue is null)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            var estatus = _mapper.Map<EstatusContribuyente>(entity);
            estatus.Id = id;
            response.Data = await _unitOfWork.estatusContribuyente.EditAsync(estatus);
            if (response.Data == true)
            {
                response.isSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
                return response;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public Task<BaseResponse<bool>> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
