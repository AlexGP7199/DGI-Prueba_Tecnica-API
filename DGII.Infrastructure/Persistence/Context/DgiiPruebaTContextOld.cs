using System;
using System.Collections.Generic;
using DGII.Domain.Entities;
using DGII.Infrastructure.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DGII.Infrastructure.Persistence.Context;

public partial class DgiiPruebaTContextOld{  /*: DbContext
{
    public DgiiPruebaTContext()
    {
    }

    public DgiiPruebaTContext(DbContextOptions<DgiiPruebaTContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contribuyente> Contribuyentes { get; set; }

    public virtual DbSet<EstatusContribuyente> EstatusContribuyentes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<TipoContribuyente> TipoContribuyentes { get; set; }

    public virtual DbSet<Ncf> Ncfs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContribuyenteConfiguration());
        modelBuilder.ApplyConfiguration(new EstatusContribuyenteConfiguration());
        modelBuilder.ApplyConfiguration(new FacturaConfiguration());
        modelBuilder.ApplyConfiguration(new TipoContribuyenteConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);{ */
}
