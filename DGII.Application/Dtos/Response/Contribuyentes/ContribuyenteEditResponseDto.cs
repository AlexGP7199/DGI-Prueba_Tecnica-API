using DGII.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Dtos.Response.Contribuyentes
{
    public class ContribuyenteEditResponseDto : BaseEntity
    {
        public string RncCedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public int TipoContribuyenteId { get; set; }

        public int EstatusContribuyenteId { get; set; }
    }
}
