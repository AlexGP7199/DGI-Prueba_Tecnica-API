using DGII.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Context.Configurations
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Factura__3213E83F3E484396");

            builder.ToTable("Factura");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Itbis18)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("itbis18");
            builder.Property(e => e.Monto)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("monto");
            builder.Property(e => e.Ncf)
                .HasMaxLength(13)
                .HasColumnName("NCF");
            //builder.HasIndex(e => e.Ncf).IsUnique();
            builder.Property(e => e.RncCedulaId).HasColumnName("rncCedulaId");

            builder.HasOne(d => d.RncCedula).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.RncCedulaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Factura__rncCedu__571DF1D5");
        }
    }
}
