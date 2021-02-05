using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EX3.Models
{
    public partial class APIContext : DbContext
    {
        
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cajero> Cajero { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Maquina> Maquina { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajero>(entity =>
            {
                entity.ToTable("Cajeros");

                entity.Property(e => e.Codigo).HasColumnName("Codigo")
                    .HasColumnType("int")
                    .UseIdentityColumn();

                entity.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasKey(e => e.Codigo);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");

                entity.Property(e => e.Codigo).HasColumnName("Codigo")
                    .HasColumnType("int")
                    .UseIdentityColumn();

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("Precio")
                    .HasColumnType("int");

                entity.HasKey(e => e.Codigo);
            });
            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.ToTable("maquinas_registradas");

                entity.Property(e => e.Codigo).HasColumnName("Codigo")
                    .HasColumnType("int")
                    .UseIdentityColumn();

                entity.Property(e => e.Piso)
                    .HasColumnType("int");

                entity.HasKey(e => e.Codigo);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");

                entity.Property(e => e.Cajero).HasColumnName("Cajero")
                    .HasColumnType("int");

                entity.Property(e => e.Maquina).HasColumnName("Maquina")
                    .HasColumnType("int");

                entity.Property(e => e.Producto).HasColumnName("Producto")
                    .HasColumnType("int");

                entity.HasKey(e => new { e.Cajero, e.Maquina, e.Producto });

                entity.HasOne(d => d.Cajeros)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Cajero)
                    .HasConstraintName("cajero_fk");

                entity.HasOne(d => d.Productos)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Producto)
                    .HasConstraintName("producto_fk");

                entity.HasOne(d => d.Maquinas)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Maquina)
                    .HasConstraintName("maquina_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
