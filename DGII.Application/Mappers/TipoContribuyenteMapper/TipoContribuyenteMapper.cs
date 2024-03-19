using AutoMapper;
using DGII.Application.Dtos.Request.TipoContribuyente;
using DGII.Application.Dtos.Response.TipoContribuyente;
using DGII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Mappers.TipoContribuyenteMapper
{
    public class TipoContribuyenteMapper : Profile
    {
        public TipoContribuyenteMapper()
        {
            CreateMap<TipoContribuyente, TipoContribuyenteAddRequestDto>().ReverseMap();
            CreateMap<TipoContribuyente, TipoContribuyenteModifyRequestDto>().ReverseMap();
            CreateMap<TipoContribuyenteResponseDto,TipoContribuyente>().ReverseMap();
        }
    }
}
