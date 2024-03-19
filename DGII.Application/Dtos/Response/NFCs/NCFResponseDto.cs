using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Dtos.Response.NFCs
{
    public class NCFResponseDto
    {
        public string? Serie { get; set; }

        public int? UltimoSecuencial { get; set; }

        public DateTime? FechaUltimoUso { get; set; }
    }
}
