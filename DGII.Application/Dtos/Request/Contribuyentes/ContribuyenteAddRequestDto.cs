using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Dtos.Request.Contribuyentes
{
    public class ContribuyenteAddRequestDto
    {
        public string RncCedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public int TipoContribuyenteId { get; set; }

        public int EstatusContribuyenteId { get; set; }
    }
}
