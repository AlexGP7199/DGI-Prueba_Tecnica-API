using DGII.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Dtos.Response.Facturas
{
    public class FacturasResponseDto : BaseEntity
    {
        public int RncCedulaId { get; set; }

        public string Ncf { get; set; } = null!;

        public decimal Monto { get; set; }

        public decimal Itbis18 { get; set; }
    }
}
