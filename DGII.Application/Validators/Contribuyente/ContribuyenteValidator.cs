using DGII.Application.Dtos.Request.Contribuyentes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Application.Validators.Contribuyente
{
    public class ContribuyenteValidator:  AbstractValidator<ContribuyenteAddRequestDto>
    {
        public ContribuyenteValidator()
        {
            RuleFor(x => x.RncCedula)
                .NotNull().WithMessage("El campo de RNC Cedula no puede ser nulo")
                .NotEmpty().WithMessage("Em campo de RNC Cedula no puede estar vacio");
            RuleFor(x => x.Nombre)
                .NotNull().WithMessage("El campo de Nombre no puede ser nulo")
                .NotEmpty().WithMessage("Em campo de Nombre puede estar vacio");
            RuleFor(x=> x.EstatusContribuyenteId)
                .NotNull().WithMessage("El campo de EstatusContribuyente no puede ser nulo")
                .NotEmpty().WithMessage("Em campo de RNC Cedula no puede estar vacio");
            RuleFor(x=>x.TipoContribuyenteId)
                .NotNull().WithMessage("El campo de TipoContribuyente no puede ser nulo")
                .NotEmpty().WithMessage("Em campo deTipoContribuyente no puede estar vacio");

        }
    }
}
