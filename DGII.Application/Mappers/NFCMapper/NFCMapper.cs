using AutoMapper;
using DGII.Application.Dtos.Request.Nfs;
using DGII.Application.Dtos.Response.NFCs;
using DGII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Mappers.NFCMapper
{
    public class NFCMapper : Profile
    {
        public NFCMapper()
        {
            CreateMap<Ncf, NCFResponseDto>().ReverseMap();
            CreateMap<Ncf, NCFsAddRequestDto>().ReverseMap();
        }
    }
}
