using System;
using System.Collections.Generic;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public partial class ScuolaDbContext : DbContext
{
    public ScuolaDbContext()
    {
    }

    public ScuolaDbContext(DbContextOptions<ScuolaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aule> Aules { get; set; }

    public virtual DbSet<Corsi> Corsis { get; set; }

    public virtual DbSet<Docenti> Docentis { get; set; }

    public virtual DbSet<DocentiCorso> DocentiCorsos { get; set; }

    public virtual DbSet<Iscrizioni> Iscrizionis { get; set; }

    public virtual DbSet<Lezioni> Lezionis { get; set; }

    public virtual DbSet<LogBackup> LogBackups { get; set; }

    public virtual DbSet<Studenti> Studentis { get; set; }

    public virtual DbSet<VwCorsi> VwCorsis { get; set; }

    public virtual DbSet<VwCorsiStato> VwCorsiStatos { get; set; }

    public virtual DbSet<VwGetCorsi> VwGetCorsis { get; set; }

    public virtual DbSet<VwStudenti> VwStudentis { get; set; }

    public virtual DbSet<VwStudentiStato> VwStudentiStatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MOUSSA\\SQLEXPRESS01;Initial Catalog=ScuolaDb;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aule>(entity =>
        {
            entity.HasKey(e => e.AulaId).HasName("PK__Aule__A8529BF897A40AE0");

            entity.ToTable("Aule");

            entity.Property(e => e.NomeAula).HasMaxLength(150);
        });

        modelBuilder.Entity<Corsi>(entity =>
        {
            entity.HasKey(e => e.CorsoId).HasName("PK__Corso__9F217D6B01EB011D");

            entity.ToTable("Corsi");

            entity.Property(e => e.DescrizioneCorso).HasMaxLength(250);
            entity.Property(e => e.NomeCorso).HasMaxLength(250);
        });

        modelBuilder.Entity<Docenti>(entity =>
        {
            entity.HasKey(e => e.DocenteId).HasName("PK__Docenti__9CB7A961602C321F");

            entity.ToTable("Docenti");

            entity.HasIndex(e => e.Email, "UQ__Docenti__A9D10534A7FFC4B1").IsUnique();

            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Specializzazione).HasMaxLength(100);
        });

        modelBuilder.Entity<DocentiCorso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DocentiC__3214EC07AF62AF6F");

            entity.ToTable("DocentiCorso");

            entity.HasOne(d => d.Corso).WithMany(p => p.DocentiCorsos)
                .HasForeignKey(d => d.CorsoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocentiCo__Corso__7D439ABD");

            entity.HasOne(d => d.Docente).WithMany(p => p.DocentiCorsos)
                .HasForeignKey(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocentiCo__Docen__7C4F7684");
        });

        modelBuilder.Entity<Iscrizioni>(entity =>
        {
            entity.HasKey(e => e.IscrizioneId).HasName("PK__Iscrizio__FB468D8370D9513E");

            entity.ToTable("Iscrizioni");

            entity.HasOne(d => d.Corso).WithMany(p => p.Iscrizionis)
                .HasForeignKey(d => d.CorsoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Iscrizion__Corso__75A278F5");

            entity.HasOne(d => d.Studente).WithMany(p => p.Iscrizionis)
                .HasForeignKey(d => d.StudenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Iscrizion__Stude__74AE54BC");
        });

        modelBuilder.Entity<Lezioni>(entity =>
        {
            entity.HasKey(e => e.LezioneId).HasName("PK__Lezioni__5244DD094E120FF5");

            entity.ToTable("Lezioni");

            entity.HasOne(d => d.Aula).WithMany(p => p.Lezionis)
                .HasForeignKey(d => d.AulaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lezioni__AulaId__797309D9");

            entity.HasOne(d => d.Corso).WithMany(p => p.Lezionis)
                .HasForeignKey(d => d.CorsoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lezioni__OraFine__787EE5A0");
        });

        modelBuilder.Entity<LogBackup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogBacku__3214EC0730A6AD50");

            entity.ToTable("LogBackup");

            entity.Property(e => e.DataBackup)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NomeDatabase).HasMaxLength(100);
            entity.Property(e => e.PercorsoFile).HasMaxLength(500);
            entity.Property(e => e.Utente).HasMaxLength(100);
        });

        modelBuilder.Entity<Studenti>(entity =>
        {
            entity.HasKey(e => e.StudenteId).HasName("PK__Studenti__EBE2AD8D6373C0E2");

            entity.ToTable("Studenti");

            entity.HasIndex(e => e.Telefono, "UQ__Studenti__4EC50480E2A3AE45").IsUnique();

            entity.HasIndex(e => e.CodiceFiscale, "UQ__Studenti__86E1BBF7FE35F8FC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Studenti__A9D10534E9ABE2D1").IsUnique();

            entity.Property(e => e.CodiceFiscale)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwCorsi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Corsi");

            entity.Property(e => e.CorsoId).ValueGeneratedOnAdd();
            entity.Property(e => e.Crediti).HasMaxLength(30);
            entity.Property(e => e.DescrizioneCorso).HasMaxLength(250);
            entity.Property(e => e.NomeDelCorso)
                .HasMaxLength(250)
                .HasColumnName("Nome del corso");
        });

        modelBuilder.Entity<VwCorsiStato>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Corsi_Stato");

            entity.Property(e => e.NomeCorso).HasMaxLength(250);
            entity.Property(e => e.StatoCorso)
                .HasMaxLength(14)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwGetCorsi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GetCorsi");

            entity.Property(e => e.CorsoId).ValueGeneratedOnAdd();
            entity.Property(e => e.DescrizioneCorso).HasMaxLength(250);
            entity.Property(e => e.NomeCorso).HasMaxLength(250);
        });

        modelBuilder.Entity<VwStudenti>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Studenti");

            entity.Property(e => e.CodiceFiscale)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DataNascita).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(153)
                .HasColumnName("Nome completo");
            entity.Property(e => e.StudenteId).ValueGeneratedOnAdd();
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwStudentiStato>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Studenti_Stato");

            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(153)
                .HasColumnName("Nome completo");
            entity.Property(e => e.Stato)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudenteId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
