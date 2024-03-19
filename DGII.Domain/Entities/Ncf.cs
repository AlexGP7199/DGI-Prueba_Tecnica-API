using DGII.Domain.Base;
using System;
using System.Collections.Generic;

namespace DGII.Domain.Entities;

public partial class Ncf : BaseEntity
{
    public string? Serie { get; set; }

    public int? UltimoSecuencial { get; set; }

    public DateTime? FechaUltimoUso { get; set; }

    public int? ContribuyenteId { get; set; }

    public virtual Contribuyente? Contribuyente { get; set; }
}
