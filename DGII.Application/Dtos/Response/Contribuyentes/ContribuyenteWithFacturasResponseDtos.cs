using DGII.Application.Dtos.Response.Facturas;
using DGII.Domain.Base;
using DGII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Dtos.Response.Contribuyentes
{
    public class ContribuyenteWithFacturasResponseDtos : BaseEntity
    {
        public string RncCedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string TipoContribuyente { get; set; }

        public string EstatusContribuyente { get; set; }

        public virtual ICollection<FacturasResponseDto> Facturas { get; set; }

    }
}
