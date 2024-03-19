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
    public class EstatusContribuyenteConfiguration : IEntityTypeConfiguration<EstatusContribuyente>
    {
        public void Configure(EntityTypeBuilder<EstatusContribuyente> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__EstatusC__3213E83F544CB0B7");

            builder.ToTable("EstatusContribuyente");

            builder.HasIndex(e => e.Descripcion, "UQ__EstatusC__92C53B6C7566F92F").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Descripcion).HasMaxLength(50);
        }

    }

}
