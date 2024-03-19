using DGII.Domain.Base;
using DGII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Dtos.Response.Contribuyentes
{
    public class ContribuyentePersonalInfoResponseDto : BaseEntity
    {
        public string RncCedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Tipo_Contribuyente { get; set; }


        public string Estatus_Contribuyente { get; set; }




    }
}
