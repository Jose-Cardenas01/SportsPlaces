using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data.Entity;

namespace SportsPlacesWeb.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Escenarios> Escenarios { get; set; }

    public virtual DbSet<Notificaciones> Notificaciones { get; set; }

    public virtual DbSet<ReportesDano> ReportesDanos { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Sedes> Sedes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=SportsPlaces; Trusted_Connection=True; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Escenarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Escenari__3213E83F8C58B69A");

            entity.ToTable("Escenario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.SedesId).HasColumnName("sedes_id");

            entity.HasOne(d => d.Sede).WithMany(p => p.Escenarios)
                .HasForeignKey(d => d.SedesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Espacio_Sedes");
        });

        modelBuilder.Entity<Notificaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83FCCC02D59");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.Mensaje)
                .IsUnicode(false)
                .HasColumnName("mensaje");
            entity.Property(e => e.TipoNotificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_notificacion");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notificacion_Usuario");
        });

        modelBuilder.Entity<ReportesDano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reportes__3213E83F8E266D26");

            entity.ToTable("ReportesDano");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EspacioId).HasColumnName("espacio_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Evidencia).HasColumnName("evidencia");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Espacio).WithMany(p => p.ReportesDanos)
                .HasForeignKey(d => d.EspacioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reporte_Espacio");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ReportesDanos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reporte_Usuario");
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3213E83F22689D38");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EspacioId).HasColumnName("espacio_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("hora");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Espacio).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EspacioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Espacio");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Usuario");
        });

        modelBuilder.Entity<Sedes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sedes__3213E83F0D49A02B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3213E83F5DB2BFD7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorreoInstitucional)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Correo_Institucional");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_usuario");
        });

        modelBuilder.Entity<Calendarios>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(e => e.Escenario)
                  .WithOne(c => c.Calendario)
                  .HasForeignKey<Calendarios>(c => c.IdEscenario);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
