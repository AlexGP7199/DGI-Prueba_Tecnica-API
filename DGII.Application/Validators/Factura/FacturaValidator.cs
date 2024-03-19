using DGII.Application.Dtos.Request.Contribuyentes;
using DGII.Application.Dtos.Request.Facturas;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Validators.Factura
{
    public class FacturaValidator : AbstractValidator<FacturaAddRequestDto>
    {
        public FacturaValidator()
        {
            // Agregar Validaciones
        }
    }
}
