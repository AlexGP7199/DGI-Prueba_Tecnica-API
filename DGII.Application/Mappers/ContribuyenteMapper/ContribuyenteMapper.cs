using AutoMapper;
using DGII.Application.Dtos.Request.Contribuyentes;
using DGII.Application.Dtos.Response.Contribuyentes;
using DGII.Domain.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Mappers.ContribuyenteMapper
{
    public class ContribuyenteMapper : Profile
    {
        public ContribuyenteMapper()
        {
            CreateMap<ContribuyentePersonalInfoResponseDto, Contribuyente>().ReverseMap()
                .ForMember(dest => dest.Tipo_Contribuyente, opt => opt.MapFrom(src => src.TipoContribuyente.Descripcion))
                .ForMember(dest => dest.Estatus_Contribuyente, opt => opt.MapFrom(src => src.EstatusContribuyente.Descripcion));
               

            CreateMap<Contribuyente, ContribuyenteAddRequestDto>().ReverseMap();
            CreateMap<Contribuyente, ContribuyenteModifyRequestDto>().ReverseMap();
            CreateMap<Contribuyente, ContribuyenteWithFacturasResponseDtos>().ReverseMap();
            CreateMap<Contribuyente, ContribuyenteEditResponseDto>().ReverseMap();

        }
    }
}
