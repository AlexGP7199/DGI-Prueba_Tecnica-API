using AutoMapper;
using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.Contribuyentes;
using DGII.Application.Dtos.Response.Contribuyentes;
using DGII.Application.Interfaces;
using DGII.Application.Validators.Contribuyente;
using DGII.Domain.Entities;
using DGII.Infrastructure.Persistence.Interfaces;
using DGII.Utilities.Static;

namespace DGII.Application.Services
{
    public class ContribuyenteApplication : IContribuyenteApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ContribuyenteValidator _validations;
        private readonly IEstatusContribuyenteApplication _estatus;

        public ContribuyenteApplication(IUnitOfWork unitOfWork, IMapper mapper, ContribuyenteValidator validations, IEstatusContribuyenteApplication estatus)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._validations = validations;
            _estatus = estatus;
        }

        public async Task<BaseResponse<CantidadContribuyentesResponse>> GetCantidadDeContribuyentes()
        {
            var response = new BaseResponse<CantidadContribuyentesResponse>();
            var data = await _unitOfWork.contribuyente.GetCantidadDeContribuyentes();
            if (data != null)
            {
                response.isSuccess = true;
                response.Data = data;
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }


        public async Task<BaseResponse<List<ContribuyentePersonalInfoResponseDto>>> GetAllContribuyenteInfo(int pageNumber, int pageSize)
        {
            var response = new BaseResponse<List<ContribuyentePersonalInfoResponseDto>>();
            var data = await _unitOfWork.contribuyente.GetAllInfoWithInclude(pageNumber, pageSize);
            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<List<ContribuyentePersonalInfoResponseDto>>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
        public async Task<BaseResponse<ContribuyentePersonalInfoResponseDto>> GetAllContribuyenteInfoById(int id)
        {
            var response = new BaseResponse<ContribuyentePersonalInfoResponseDto>();
            var data = await _unitOfWork.contribuyente.GetContribuyenteByIdWithInclude(id);
            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<ContribuyentePersonalInfoResponseDto>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

      

      
        public async Task<BaseResponse<bool>> RegisterContribuyente(ContribuyenteAddRequestDto _contribuyente)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validations.ValidateAsync(_contribuyente);
            if(!validationResult.IsValid)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            var contibuyente = _mapper.Map<Contribuyente>(_contribuyente);
            var validateCedula = await _unitOfWork.contribuyente.GetContribuyenteByRncCedula(_contribuyente.RncCedula);
            if (validateCedula != null)
            {
                response.isSuccess = false;
                response.Message = "Esta cedula ya esta siendo usada";
                return response;
            }
            var validateEstatus = await _unitOfWork.estatusContribuyente.GetByIdAsync(_contribuyente.EstatusContribuyenteId);
            if(validateEstatus == null)
            {
                response.isSuccess = false;
                response.Message = "El estatus seleccionado, no existe";
                return response;
            }
            var validateTipo = await _unitOfWork.tipoContribuyente.GetByIdAsync(_contribuyente.TipoContribuyenteId);
            if (validateTipo == null)
            {

                response.isSuccess = false;
                response.Message = "El tipo seleccionado, no existe";
                return response;
            }
            response.Data = await _unitOfWork.contribuyente.RegisterAsync(contibuyente);
            if(response.Data == true)
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

        
        public async Task<BaseResponse<bool>> UpdateContribuyente(int id, ContribuyenteModifyRequestDto _contribuyente)
        {
            var response = new BaseResponse<bool>();
            //var validationResult = await _validations.ValidateAsync(_contribuyente);
            var contribuyenteValue = await GetContribuyenteById(id);
            if (contribuyenteValue is null)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            var contribuyente = _mapper.Map<Contribuyente>(_contribuyente);
            contribuyente.Id = id;
            var validateCedula = await _unitOfWork.contribuyente.GetContribuyenteByRncCedula(_contribuyente.RncCedula);
            if (validateCedula != null && validateCedula.Id != contribuyente.Id)
            {
                response.isSuccess = false;
                response.Message = "Esta cedula ya esta siendo usada";
                return response;
            }
            if(validateCedula.RncCedula != contribuyente.RncCedula)
            {
                var facturaWithCedulas = await _unitOfWork.factura.GetCantidadFacturasByContribuyenteId(id);
                if (facturaWithCedulas != null)
                {
                    response.isSuccess = false;
                    response.Message = "No puedes realizar esta accion, tienes facturas a tu nombre";
                    return response;
                }
            }
            
            var validateEstatus = await _unitOfWork.estatusContribuyente.GetByIdAsync(_contribuyente.EstatusContribuyenteId);
            if (validateEstatus == null)
            {
                response.isSuccess = false;
                response.Message = "El estatus seleccionado, no existe";
                return response;
            }
            var validateTipo = await _unitOfWork.tipoContribuyente.GetByIdAsync(_contribuyente.TipoContribuyenteId);
            if (validateTipo == null)
            {

                response.isSuccess = false;
                response.Message = "El tipo seleccionado, no existe";
                return response;
            }
            response.Data = await _unitOfWork.contribuyente.EditAsync(contribuyente);
            if (response.Data == true)
            {
                response.isSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
                return response;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }


        public async Task<ContribuyentePersonalInfoResponseDto> GetContribuyenteByType(int tipoContribuyenteId)
        {
            var data = await _unitOfWork.contribuyente.GetContribuyenteByType(tipoContribuyenteId);
            var existContribuyenteWithType = _mapper.Map<ContribuyentePersonalInfoResponseDto>(data);
            return existContribuyenteWithType;
        }

        public async Task<ContribuyenteEditResponseDto> GetContribuyenteById(int id)
        {
            var data = await _unitOfWork.contribuyente.GetByIdAsync(id);
            var contribuyente = _mapper.Map<ContribuyenteEditResponseDto>(data);
            return contribuyente;
        }

        public async Task<ContribuyentePersonalInfoResponseDto> GetContribuyenteByEstatus(int estatusContribuyenteId)
        {
            var data = await _unitOfWork.contribuyente.GetContribuyenteByEstatus(estatusContribuyenteId);
            var existContribuyenteWithEstatus = _mapper.Map<ContribuyentePersonalInfoResponseDto>(data);
            return existContribuyenteWithEstatus;
        }

        public async Task<ContribuyentePersonalInfoResponseDto> GetContribuyenteByRncCedula(string rncCedula)
        {
            var data = await _unitOfWork.contribuyente.GetContribuyenteByRncCedula(rncCedula);
            var existContribuyente = _mapper.Map<ContribuyentePersonalInfoResponseDto>(data);
            return existContribuyente;
        }


        /*
        public async Task<BaseResponse<bool>> ChangeContribuyenteStatus(int id, int status)
        {
            var response = new BaseResponse<bool>();

            var contribuyenteValue = await GetAllContribuyenteInfoById(id);
            if (contribuyenteValue is null)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }
            var estatusExist = await _estatus.GetByIdAsync(id);
            if(estatusExist.Data is null)
            {
                response.isSuccess = false;
                response.Message = "Ese estatus no existe";
                return response;
            }

            var contribuyente = _mapper.Map<Contribuyente>(contribuyenteValue);
            contribuyente.Id=id;
            contribuyente.EstatusContribuyenteId = status;
            response.Data = await _unitOfWork.contribuyente.EditAsync(contribuyente);
        } */

        /*
      public async Task<BaseResponse<ContribuyenteWithFacturasResponseDtos>> GetContribuyenteByIdWithFacturas(int id)
      {
          var response = new BaseResponse<ContribuyenteWithFacturasResponseDtos>();
          var data = await _unitOfWork.contribuyente.GetContribuyenteWithFacturas(id);
          if (data != null)
          {
              response.isSuccess = true;
              response.Data = _mapper.Map<ContribuyenteWithFacturasResponseDtos>(data);
              response.Message = ReplyMessage.MESSAGE_QUERY;
          }
          else
          {
              response.isSuccess = false;
              response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
          }
          return response;
      } */

    }
}
