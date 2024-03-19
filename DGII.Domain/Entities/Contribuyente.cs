using DGII.Domain.Base;
using System;
using System.Collections.Generic;

namespace DGII.Domain.Entities;

public partial class Contribuyente : BaseEntity
{
   
    public string RncCedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int TipoContribuyenteId { get; set; }

    public int EstatusContribuyenteId { get; set; }

    public virtual EstatusContribuyente EstatusContribuyente { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Ncf> Ncfs { get; set; } = new List<Ncf>();

    public virtual TipoContribuyente TipoContribuyente { get; set; } = null!;
}
