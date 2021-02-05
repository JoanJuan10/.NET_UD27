using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EX4.Models
{
    public partial class APIContext : DbContext
    {
        
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Investigador> Investigador { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investigador>(entity =>
            {
                entity.ToTable("Investigadores");

                entity.Property(e => e.DNI).HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Facultad).HasColumnName("Facultad")
                    .HasColumnType("int");

                entity.HasOne(d => d.Facultades)
                    .WithMany(p => p.Investigadores)
                    .HasForeignKey(d => d.Facultad)
                    .HasConstraintName("facultad_fk");

                entity.HasKey(e => e.DNI);
            });
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipos");

                entity.Property(e => e.NumSerie).HasColumnName("NumSerie")
                    .HasMaxLength(4)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre).HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasKey(e => e.NumSerie);

                entity.HasOne(d => d.Facultad)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.IDFacultad)
                    .HasConstraintName("equipo_fk");
            });


            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.ToTable("Facultad");

                entity.Property(e => e.Codigo).HasColumnName("Codigo")
                    .HasColumnType("int")
                    .UseIdentityColumn();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasKey(e => e.Codigo);
            });

            
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");

                entity.Property(e => e.DNI).HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.NumSerie).HasColumnName("NumSerie")
                    .HasColumnType("char")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Comienzo)
                    .HasColumnName("Comienzo")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fin)
                    .HasColumnName("Fin")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Investigadores)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.DNI)
                    .HasConstraintName("investigador_fk");

                entity.HasOne(d => d.Equipos)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.NumSerie)
                    .HasConstraintName("reserva_fk");

                entity.HasKey(e => new { e.DNI, e.NumSerie});
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
