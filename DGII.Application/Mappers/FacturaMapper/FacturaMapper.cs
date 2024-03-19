using AutoMapper;
using DGII.Application.Dtos.Request.Facturas;
using DGII.Application.Dtos.Response.Facturas;
using DGII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Mappers.FacturaMapper
{
    public class FacturaMapper : Profile
    {
        public FacturaMapper()
        {
            CreateMap<Factura, FacturasResponseDto>().ReverseMap();
            CreateMap<FacturaAddRequestDto, Factura>().ReverseMap().ForMember(dest => dest.RncCedula, opt => opt.Ignore());
            CreateMap<FacturaModifyRequestDto, Factura>().ReverseMap().ForMember(dest => dest.RncCedula, opt => opt.Ignore());
        }
    }
}
