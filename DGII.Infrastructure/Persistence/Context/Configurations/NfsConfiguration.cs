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
    public class NfsConfiguration : IEntityTypeConfiguration<Ncf> { 
    
        public void Configure(EntityTypeBuilder<Ncf> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__NCFs__3214EC0743BB4773");

            builder.ToTable("NCFs");

            builder.Property(e => e.ContribuyenteId).HasColumnName("contribuyenteId");
            builder.Property(e => e.FechaUltimoUso).HasColumnType("datetime");
            builder.Property(e => e.Serie).HasMaxLength(20);

            builder.HasOne(d => d.Contribuyente).WithMany(p => p.Ncfs)
                .HasForeignKey(d => d.ContribuyenteId)
                .HasConstraintName("FK__NCFs__contribuye__5FB337D6");
        }
    }
}
