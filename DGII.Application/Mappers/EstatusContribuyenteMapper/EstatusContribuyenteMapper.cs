using AutoMapper;
using DGII.Application.Dtos.Request.EstatusContribuyentes;
using DGII.Application.Dtos.Response.EstatusContribuyentes;
using DGII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Mappers.EstatusContribuyenteMapper
{
    public class EstatusContribuyenteMapper : Profile
    {
        public EstatusContribuyenteMapper()
        {
            CreateMap<EstatusContribuyente, EstatusContribuyenteAddRequestDto>().ReverseMap();
            CreateMap<EstatusContribuyente, EstatusContribuyenteModifyRequestDto>().ReverseMap();
            CreateMap<EstatusContribuyenteResponseDto,EstatusContribuyente>().ReverseMap();

        }   
    }
}
