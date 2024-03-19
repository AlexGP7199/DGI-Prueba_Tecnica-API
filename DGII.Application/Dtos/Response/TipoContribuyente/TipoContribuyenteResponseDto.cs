using DGII.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Dtos.Response.TipoContribuyente
{
    public class TipoContribuyenteResponseDto : BaseEntity
    {
        public string Descripcion { get; set; } = null!;
    }
}
