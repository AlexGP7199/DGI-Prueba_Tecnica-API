using DGII.Domain.Base;
using System;
using System.Collections.Generic;

namespace DGII.Domain.Entities;

public partial class Factura : BaseEntity
{
   
    public int RncCedulaId { get; set; }

    public string Ncf { get; set; } = null!;

    public decimal Monto { get; set; }

    public decimal Itbis18 { get; set; }

    public virtual Contribuyente RncCedula { get; set; } = null!;
}
