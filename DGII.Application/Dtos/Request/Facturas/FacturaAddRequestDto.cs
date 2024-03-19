using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Dtos.Request.Facturas
{
    public class FacturaAddRequestDto
    {
        
        public string RncCedula { get; set; }
        public decimal Monto { get; set; }

        
    }
}
