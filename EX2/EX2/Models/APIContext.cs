using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EX2.Models
{
    public partial class APIContext : DbContext
    {
        
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cientifico> Cientifico { get; set; }
        public virtual DbSet<Asignado> Asignado { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientifico>(entity =>
            {
                entity.ToTable("Cientificos");

                entity.Property(e => e.DNI).HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasKey(e => e.DNI);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("Proyecto");

                entity.Property(e => e.Id).HasColumnName("Id")
                    .HasColumnType("char")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Horas)
                    .HasColumnName("Horas")
                    .HasColumnType("int");

                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Asignado>(entity =>
            {
                entity.ToTable("Asignado_a");

                entity.Property(e => e.DNICientifico).HasColumnName("Cientifico")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IDProyecto).HasColumnName("Proyecto")
                    .HasColumnType("char")
                    .HasMaxLength(4);

                entity.HasKey(e => new { e.DNICientifico, e.IDProyecto });

                entity.HasOne(d => d.Cientificos)
                    .WithMany(p => p.CientificoAsignadoA)
                    .HasForeignKey(d => d.DNICientifico)
                    .HasConstraintName("cientifico_fk");

                entity.HasOne(d => d.Proyectos)
                    .WithMany(p => p.ProyectoAsignadoA)
                    .HasForeignKey(d => d.IDProyecto)
                    .HasConstraintName("proyecto_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
