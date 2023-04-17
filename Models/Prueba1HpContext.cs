using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_1_HP.Models;

public partial class Prueba1HpContext : DbContext
{
    public Prueba1HpContext()
    {
    }

    public Prueba1HpContext(DbContextOptions<Prueba1HpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<AsignaturaCursadum> AsignaturaCursada { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.CodigoAsignatura).HasName("PRIMARY");

            entity.ToTable("asignaturas");

            entity.Property(e => e.CodigoAsignatura)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("codigo_asignatura");
            entity.Property(e => e.DescripcionAsignatura)
                .HasMaxLength(255)
                .HasColumnName("descripcion_asignatura");
            entity.Property(e => e.FechaActualizaciónAsignatura)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnName("fecha_actualización_asignatura");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(16)
                .HasColumnName("nombre_asignatura");
        });

        modelBuilder.Entity<AsignaturaCursadum>(entity =>
        {
            entity.HasKey(e => e.IdAsignaturaCursada).HasName("PRIMARY");

            entity.ToTable("asignatura_cursada");

            entity.HasIndex(e => e.AsignaturasCodigoAsignatura, "fk_asignatura_cursada_Asignaturas1_idx");

            entity.HasIndex(e => e.EstudiantesRutEstudiante, "fk_asignatura_cursada_Estudiantes_idx");

            entity.Property(e => e.IdAsignaturaCursada)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_asignatura_cursada");
            entity.Property(e => e.AsignaturasCodigoAsignatura)
                .HasColumnType("int(11)")
                .HasColumnName("Asignaturas_codigo_asignatura");
            entity.Property(e => e.EstudiantesRutEstudiante)
                .HasMaxLength(30)
                .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                .HasColumnName("Estudiantes_rut_estudiante");

            entity.HasOne(d => d.AsignaturasCodigoAsignaturaNavigation).WithMany(p => p.AsignaturaCursada)
                .HasForeignKey(d => d.AsignaturasCodigoAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_asignatura_cursada_Asignaturas1");

            entity.HasOne(d => d.EstudiantesRutEstudianteNavigation).WithMany(p => p.AsignaturaCursada)
                .HasForeignKey(d => d.EstudiantesRutEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_asignatura_cursada_Estudiantes");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.RutEstudiante).HasName("PRIMARY");

            entity.ToTable("estudiantes");

            entity.Property(e => e.RutEstudiante)
                .HasMaxLength(30)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnName("rut_estudiante");
            entity.Property(e => e.ApellidoEstudiante)
                .HasMaxLength(32)
                .HasColumnName("apellido_estudiante");
            entity.Property(e => e.DireccionEstudiante)
                .HasMaxLength(45)
                .HasColumnName("direccion_estudiante");
            entity.Property(e => e.EdadEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("edad_estudiante");
            entity.Property(e => e.EmailEstudiante)
                .HasMaxLength(255)
                .HasColumnName("email_estudiante");
            entity.Property(e => e.FechaNacimientoEstudiante).HasColumnName("fecha_nacimiento_estudiante");
            entity.Property(e => e.NombreEstudiante)
                .HasMaxLength(16)
                .HasColumnName("nombre_estudiante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
