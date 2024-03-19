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
    public class TipoContribuyenteConfiguration : IEntityTypeConfiguration<TipoContribuyente>
    {
        public void Configure(EntityTypeBuilder<TipoContribuyente> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__TipoCont__3213E83F9085C032");

            builder.ToTable("TipoContribuyente");

            builder.HasIndex(e => e.Descripcion, "UQ__TipoCont__92C53B6CCF484A14").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Descripcion).HasMaxLength(50);
        }
    }
}
