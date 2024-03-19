using DGII.Application.Dtos.Request.TipoContribuyente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Validators.TipoContribuyente
{
    public class TipoContribuyenteValidator : AbstractValidator<TipoContribuyenteAddRequestDto>
    {
        public TipoContribuyenteValidator()
        {
            // Agregar Validaciones
        }
    }
}
