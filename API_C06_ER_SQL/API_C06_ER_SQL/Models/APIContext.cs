using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EX1.Models
{
    public partial class APIContext : DbContext
    {
        
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pieza> Pieza { get; set; }
        public virtual DbSet<Suministra> Suministra { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pieza>(entity =>
            {
                entity.ToTable("Piezas");

                entity.Property(e => e.Codigo).HasColumnName("Codigo");

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasKey(e => e.Codigo);
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedores");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.ToTable("Suministra");

                entity.Property(e => e.CodigoPieza).HasColumnName("CodigoPieza")
                    .HasColumnType("int");

                entity.Property(e => e.IdProveedor).HasColumnName("IdProveedor")
                    .HasColumnType("char")
                    .HasMaxLength(4);

                entity.Property(e => e.Precio).HasColumnName("Precio")
                    .HasColumnType("int");

                entity.HasKey(e => new { e.CodigoPieza, e.IdProveedor});

                entity.HasOne(d => d.Pieza)
                    .WithMany(p => p.Suministras)
                    .HasForeignKey(d => d.CodigoPieza)
                    .HasConstraintName("pieza_fk");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Suministras)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("proveedor_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
