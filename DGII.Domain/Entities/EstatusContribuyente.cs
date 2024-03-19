using DGII.Domain.Base;
using System;
using System.Collections.Generic;

namespace DGII.Domain.Entities;

public partial class EstatusContribuyente : BaseEntity
{


    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Contribuyente> Contribuyentes { get; set; } = new List<Contribuyente>();
}
