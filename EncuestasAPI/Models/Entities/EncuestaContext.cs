using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EncuestasAPI.Models.Entities;

public partial class EncuestaContext : DbContext
{
    public EncuestaContext()
    {
    }

    public EncuestaContext(DbContextOptions<EncuestaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Encuesta> Encuesta { get; set; }

    public virtual DbSet<Encuestadetalle> Encuestadetalle { get; set; }

 


    public virtual DbSet<Pregunta> Pregunta { get; set; }




    public virtual DbSet<Respuesta> Respuesta { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=65.181.111.21;database=encuesta;user=websitos_encuesta;password=encuesta2025@D", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.8-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Encuesta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("encuesta");

            entity.HasIndex(e => e.IdUsuario, "fkIdusuario");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fkIdusuario");
        });

        modelBuilder.Entity<Encuestadetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("encuestadetalle");

            entity.HasIndex(e => e.IdPregunta, "fkIdPregunta");

            entity.HasIndex(e => e.IdRespuesta, "fkIdRespuesta");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdPregunta).HasColumnType("int(11)");
            entity.Property(e => e.IdRespuesta).HasColumnType("int(11)");
            entity.Property(e => e.ValorEvaluacion).HasColumnType("int(11)");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.Encuestadetalle)
                .HasForeignKey(d => d.IdPregunta)
                .HasConstraintName("fkIdPregunta");

            entity.HasOne(d => d.IdRespuestaNavigation).WithMany(p => p.Encuestadetalle)
                .HasForeignKey(d => d.IdRespuesta)
                .HasConstraintName("fkIdRespuesta");
        });

       

      
        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PRIMARY");

            entity.ToTable("pregunta");

            entity.HasIndex(e => e.IdEncuesta, "fkPreguntaEncuesta_idx");

            entity.Property(e => e.IdPregunta).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.IdEncuesta).HasColumnType("int(11)");
            entity.Property(e => e.NumeroPregunta).HasColumnType("int(11)");

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.IdEncuesta)
                .HasConstraintName("fkPreguntaEncuesta");
        });

      

    

        modelBuilder.Entity<Respuesta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("respuesta");

            entity.HasIndex(e => e.IdEncuesta, "fkEncuestaId");

            entity.HasIndex(e => e.IdUsuarioAplicador, "fkUsuarioAplicador");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.FechaAplicacion).HasColumnType("datetime");
            entity.Property(e => e.IdEncuesta).HasColumnType("int(11)");
            entity.Property(e => e.IdUsuarioAplicador).HasColumnType("int(11)");
            entity.Property(e => e.NombreAlumno).HasMaxLength(150);
            entity.Property(e => e.NumControlAlumno).HasMaxLength(10);

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.IdEncuesta)
                .HasConstraintName("fkEncuestaId");

            entity.HasOne(d => d.IdUsuarioAplicadorNavigation).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.IdUsuarioAplicador)
                .HasConstraintName("fkUsuarioAplicador");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Contrasena).HasMaxLength(10);
            entity.Property(e => e.EsAdmin).HasMaxLength(10);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

     

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
