using DGII.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DGII.Infrastructure.Persistence.Context;
public partial class DgiiPruebaTContext : DbContext
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

    public virtual DbSet<Ncf> Ncfs { get; set; }

    public virtual DbSet<TipoContribuyente> TipoContribuyentes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contribuyente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contribu__3213E83FDAB4B1D9");

            entity.ToTable("Contribuyente");

            entity.HasIndex(e => e.RncCedula, "UQ__Contribu__38AA49B251DDA23A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.RncCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("rncCedula");

            entity.HasOne(d => d.EstatusContribuyente).WithMany(p => p.Contribuyentes)
                .HasForeignKey(d => d.EstatusContribuyenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contribuy__Estat__5441852A");

            entity.HasOne(d => d.TipoContribuyente).WithMany(p => p.Contribuyentes)
                .HasForeignKey(d => d.TipoContribuyenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contribuy__TipoC__534D60F1");
        });

        modelBuilder.Entity<EstatusContribuyente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstatusC__3213E83F544CB0B7");

            entity.ToTable("EstatusContribuyente");

            entity.HasIndex(e => e.Descripcion, "UQ__EstatusC__92C53B6C7566F92F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Factura__3213E83F3E484396");

            entity.ToTable("Factura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Itbis18)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("itbis18");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.Ncf)
                .HasMaxLength(13)
                .HasColumnName("NCF");
            entity.Property(e => e.RncCedulaId).HasColumnName("rncCedulaId");

            entity.HasOne(d => d.RncCedula).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.RncCedulaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Factura__rncCedu__571DF1D5");
        });

        modelBuilder.Entity<Ncf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NCFs__3214EC0743BB4773");

            entity.ToTable("NCFs");

            entity.Property(e => e.ContribuyenteId).HasColumnName("contribuyenteId");
            entity.Property(e => e.FechaUltimoUso).HasColumnType("datetime");
            entity.Property(e => e.Serie).HasMaxLength(20);

            entity.HasOne(d => d.Contribuyente).WithMany(p => p.Ncfs)
                .HasForeignKey(d => d.ContribuyenteId)
                .HasConstraintName("FK__NCFs__contribuye__5FB337D6");
        });

        modelBuilder.Entity<TipoContribuyente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoCont__3213E83F9085C032");

            entity.ToTable("TipoContribuyente");

            entity.HasIndex(e => e.Descripcion, "UQ__TipoCont__92C53B6CCF484A14").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
