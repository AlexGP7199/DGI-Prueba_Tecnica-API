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
    public class ContribuyenteConfiguration : IEntityTypeConfiguration<Contribuyente>
    {
        public void Configure(EntityTypeBuilder<Contribuyente> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Contribu__3213E83FDAB4B1D9");

            builder.ToTable("Contribuyente");

            builder.HasIndex(e => e.RncCedula, "UQ__Contribu__38AA49B251DDA23A").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            builder.Property(e => e.RncCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("rncCedula");

            builder.HasOne(d => d.EstatusContribuyente).WithMany(p => p.Contribuyentes)
                .HasForeignKey(d => d.EstatusContribuyenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contribuy__Estat__5441852A");

            builder.HasOne(d => d.TipoContribuyente).WithMany(p => p.Contribuyentes)
                .HasForeignKey(d => d.TipoContribuyenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contribuy__TipoC__534D60F1");
        }
    }
}
