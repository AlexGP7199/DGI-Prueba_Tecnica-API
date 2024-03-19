using AutoMapper;
using DGII.Application.Commons.Base;
using DGII.Application.Dtos.Request.Facturas;
using DGII.Application.Dtos.Response.Contribuyentes;
using DGII.Application.Dtos.Response.Facturas;
using DGII.Application.Interfaces;
using DGII.Application.Validators.Contribuyente;
using DGII.Application.Validators.Factura;
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
    public class FacturaApplication : IFacturaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly FacturaValidator _validations;
        private readonly IContribuyenteApplication _contribuyente;
        private readonly INCFsApplication _ncfs;

        public FacturaApplication(IUnitOfWork unitOfWork, IMapper mapper, FacturaValidator validations, IContribuyenteApplication contribuyente, INCFsApplication ncfs)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validations = validations;
            _contribuyente = contribuyente;
            _ncfs = ncfs;
        }

        public async Task<BaseResponse<CantidadFacturasResponse>> GetCantidadFacturasByContribuyenteId(int contribuyenteId)
        {
            var response = new BaseResponse<CantidadFacturasResponse>();
            var data = await _unitOfWork.factura.GetCantidadFacturasByContribuyenteId(contribuyenteId);
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

        public async Task<BaseResponse<IEnumerable<FacturasResponseDto>>> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<FacturasResponseDto>>();
            var data = await _unitOfWork.factura.GetAllAsync();
            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<IEnumerable<FacturasResponseDto>>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<List<FacturasResponseDto>>> getAllFacturasByRncCedulaId(int rncCedulaId, int pageNumber, int pageSize)
        {
            var response = new BaseResponse<List<FacturasResponseDto>>();
            var data = await _unitOfWork.factura.getAllFacturasByRncCedulaId(rncCedulaId, pageNumber, pageSize);
            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<List<FacturasResponseDto>>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<FacturasResponseDto>> GetByIdAsync(int id)
        {
            var response = new BaseResponse<FacturasResponseDto>();
            var data = await _unitOfWork.factura.GetByIdAsync(id);
            if (data != null)
            {
                response.isSuccess = true;
                response.Data = _mapper.Map<FacturasResponseDto>(data);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<FacturaMontoTotalResponseDto>> GetMontoTotalItbisById(int contribuyenteId)
        {

            var response = new BaseResponse<FacturaMontoTotalResponseDto>();
            var data = await _unitOfWork.factura.GetMontoTotalByContribuyenteId(contribuyenteId);
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

    
        public async Task<BaseResponse<bool>> RegisterAsync(FacturaAddRequestDto entity)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validations.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                response.isSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            var validateRnc = await _contribuyente.GetContribuyenteByRncCedula(entity.RncCedula);
            if(validateRnc is null)
            {
                response.isSuccess = false;
                response.Message = "Ese RNC de cedula no existe";
                return response;
            }

            var factura = new Factura();
            factura.Monto = entity.Monto;
            decimal itbis = 0.18m;
            factura.RncCedulaId = validateRnc.Id;
            factura.Itbis18 = factura.Monto * itbis;

            var dataNcfContribuyente = await _ncfs.getContrubuyenteNFCinfoByIdContribuyente(factura.RncCedulaId);

            var dataUpdated = _mapper.Map<Ncf>(dataNcfContribuyente);
            dataUpdated.ContribuyenteId = factura.RncCedulaId;
            dataUpdated.UltimoSecuencial = dataUpdated.UltimoSecuencial + 1;
            factura.Ncf = $"{dataUpdated.Serie}{dataUpdated.UltimoSecuencial:00000000}";
            
            await _ncfs.EditAsync(dataUpdated);

            response.Data = await _unitOfWork.factura.RegisterAsync(factura);
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
        public Task<BaseResponse<bool>> EditAsync(FacturaModifyRequestDto entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
