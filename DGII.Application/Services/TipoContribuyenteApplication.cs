using AutoMapper;
using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.TipoContribuyente;
using DGII.Application.Dtos.Response.TipoContribuyente;
using DGII.Application.Interfaces;
using DGII.Application.Validators.TipoContribuyente;
using DGII.Domain.Entities;
using DGII.Infrastructure.Persistence.Interfaces;
using DGII.Utilities.Static;


namespace DGII.Application.Services
{
    public class TipoContribuyenteApplication : ITipoContribuyenteApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TipoContribuyenteValidator _validations;
        private readonly IContribuyenteApplication _contribuyentes;
        public TipoContribuyenteApplication(IUnitOfWork unitOfWork, IMapper mapper, TipoContribuyenteValidator validations, IContribuyenteApplication contribuyentes)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validations = validations;
            _contribuyentes = contribuyentes;
        }
        public async Task<BaseResponse<IEnumerable<TipoContribuyenteResponseDto>>> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<TipoContribuyenteResponseDto>>();
            var data = await _unitOfWork.tipoContribuyente.GetAllAsync();

            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<IEnumerable<TipoContribuyenteResponseDto>> (data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<TipoContribuyenteResponseDto>> GetByIdAsync(int id)
        {
            var response = new BaseResponse<TipoContribuyenteResponseDto>();
            var data = await _unitOfWork.tipoContribuyente.GetByIdAsync(id);

            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<TipoContribuyenteResponseDto>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterAsync(TipoContribuyenteAddRequestDto entity)
        {
            var response = new BaseResponse<bool>();
            var validatonResult = await _validations.ValidateAsync(entity);
            if(!validatonResult.IsValid)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validatonResult.Errors;
                return response;
            }
            var contribuyente = _mapper.Map<TipoContribuyente>(entity);
            response.Data = await _unitOfWork.tipoContribuyente.RegisterAsync(contribuyente);
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

        public async Task<BaseResponse<bool>> EditAsync(int id, TipoContribuyenteModifyRequestDto entity)
        {
            var response = new BaseResponse<bool>();
            var tipoContribuyenteExist = await GetByIdAsync(id);
            if (tipoContribuyenteExist.Data is null)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            var tipoContribuyente = _mapper.Map<TipoContribuyente>(entity);
            tipoContribuyente.Id = id;
            response.Data = await _unitOfWork.tipoContribuyente.EditAsync(tipoContribuyente);

            if (response.Data == true)
            {
                response.isSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        
        public async Task<BaseResponse<bool>> RemoveAsync(int id)
        {
            var response = new BaseResponse<bool>();
            var movie = await GetByIdAsync(id);

            if (movie.Data is null)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            // Funcion para validar ningun contribuyente tiene este tipo
            var validedTypeIsNotAssign = _contribuyentes.GetContribuyenteByType(id);
            if(validedTypeIsNotAssign is not null)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_NOT_ABLE_TO_ERASE;
                return response;
            }

            response.Data = await _unitOfWork.tipoContribuyente.RemoveAsync(id);

            if (response.Data)
            {
                response.isSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
    }
}
