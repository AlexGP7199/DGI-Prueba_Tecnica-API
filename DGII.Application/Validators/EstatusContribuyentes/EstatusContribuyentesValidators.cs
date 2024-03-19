using DGII.Application.Dtos.Request.EstatusContribuyentes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Validators.EstatusContribuyentes
{
    public class EstatusContribuyentesValidators : AbstractValidator<EstatusContribuyenteAddRequestDto>
    {
        public EstatusContribuyentesValidators()
        {
            // Agregar Validators
        }
    }
}
