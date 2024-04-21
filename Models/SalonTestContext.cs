using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERP_SalonNamestaja.Models;

public partial class SalonTestContext : DbContext
{
    public SalonTestContext()
    {
    }

    public SalonTestContext(DbContextOptions<SalonTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategorija> Kategorijas { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<Lokacija> Lokacijas { get; set; }

    public virtual DbSet<Porudzbina> Porudzbinas { get; set; }

    public virtual DbSet<Proizvod> Proizvods { get; set; }

    public virtual DbSet<Proizvodjac> Proizvodjacs { get; set; }

    public virtual DbSet<Prostorija> Prostorijas { get; set; }

    public virtual DbSet<Stanje> Stanjes { get; set; }

    public virtual DbSet<StavkaPorudzbine> StavkaPorudzbines { get; set; }

    public virtual DbSet<Uloga> Ulogas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=SalonTest;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategorija>(entity =>
        {
            entity.HasKey(e => e.KategorijaId).HasName("PK__Kategori__487607FBB88D6D55");

            entity.ToTable("Kategorija");

            entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");
            entity.Property(e => e.NazivKat)
                .HasMaxLength(20)
                .HasColumnName("nazivKat");
            entity.Property(e => e.ProstorijaId).HasColumnName("prostorija_id");

            entity.HasOne(d => d.Prostorija).WithMany(p => p.Kategorijas)
                .HasForeignKey(d => d.ProstorijaId)
                .HasConstraintName("FK_Kategorija_Prostorija");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.KorisnikId).HasName("PK__Korisnik__B84D9F56F98B3FDF");

            entity.ToTable("Korisnik");

            entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");
            entity.Property(e => e.Adresa)
                .HasMaxLength(100)
                .HasColumnName("adresa");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .HasColumnName("email");
            entity.Property(e => e.Ime)
                .HasMaxLength(25)
                .HasColumnName("ime");
            entity.Property(e => e.PasswordHash).HasColumnName("passwordHash");
            entity.Property(e => e.PasswordSalt).HasColumnName("passwordSalt");
            entity.Property(e => e.Prezime)
                .HasMaxLength(25)
                .HasColumnName("prezime");
            entity.Property(e => e.Telefon)
                .HasMaxLength(15)
                .HasColumnName("telefon");
            entity.Property(e => e.UlogaId).HasColumnName("uloga_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Uloga).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.UlogaId)
                .HasConstraintName("FK_Korisnik_Uloga");
        });

        modelBuilder.Entity<Lokacija>(entity =>
        {
            entity.HasKey(e => e.LokacijaId).HasName("PK__Lokacija__B9590D42FAAF698D");

            entity.ToTable("Lokacija");

            entity.Property(e => e.LokacijaId).HasColumnName("lokacija_id");
            entity.Property(e => e.Adresa)
                .HasMaxLength(50)
                .HasColumnName("adresa");
            entity.Property(e => e.Grad)
                .HasMaxLength(25)
                .HasColumnName("grad");
        });

        modelBuilder.Entity<Porudzbina>(entity =>
        {
            entity.HasKey(e => e.PorudzbinaId).HasName("PK__Porudzbi__14368C0A8DE23355");

            entity.ToTable("Porudzbina");

            entity.Property(e => e.PorudzbinaId).HasColumnName("porudzbina_id");
            entity.Property(e => e.AdresaIsporuke)
                .HasMaxLength(100)
                .HasColumnName("adresaIsporuke");
            entity.Property(e => e.DatumKreiranja)
                .HasColumnType("date")
                .HasColumnName("datumKreiranja");
            entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");
            entity.Property(e => e.UkupnaCena).HasColumnName("ukupnaCena");
            entity.Property(e => e.VremeKreiranja).HasColumnName("vremeKreiranja");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Porudzbinas)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Porudzbina_Korisnik");
        });

        modelBuilder.Entity<Proizvod>(entity =>
        {
            entity.HasKey(e => e.ProizvodId).HasName("PK__Proizvod__E52BF354F72D8991");

            entity.ToTable("Proizvod");

            entity.Property(e => e.ProizvodId).HasColumnName("proizvod_id");
            entity.Property(e => e.Cena).HasColumnName("cena");
            entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");
            entity.Property(e => e.Materijal)
                .HasMaxLength(30)
                .HasColumnName("materijal");
            entity.Property(e => e.Naziv)
                .HasMaxLength(10)
                .HasColumnName("naziv");
            entity.Property(e => e.Opis)
                .HasMaxLength(500)
                .HasColumnName("opis");
            entity.Property(e => e.ProizvodjacId).HasColumnName("proizvodjac_id");
            entity.Property(e => e.SifraProizvod)
                .HasMaxLength(20)
                .HasColumnName("sifraProizvod");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Proizvods)
                .HasForeignKey(d => d.KategorijaId)
                .HasConstraintName("FK_Proizvod_Kategorija");

            entity.HasOne(d => d.Proizvodjac).WithMany(p => p.Proizvods)
                .HasForeignKey(d => d.ProizvodjacId)
                .HasConstraintName("FK_Proizvod_Proizvodjac");
        });

        modelBuilder.Entity<Proizvodjac>(entity =>
        {
            entity.HasKey(e => e.ProizvodjacId).HasName("PK__Proizvod__DD4E5AFAA3A013DB");

            entity.ToTable("Proizvodjac");

            entity.Property(e => e.ProizvodjacId).HasColumnName("proizvodjac_id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(20)
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Prostorija>(entity =>
        {
            entity.HasKey(e => e.ProstorijaId).HasName("PK__Prostori__30BBABB1E9CB3142");

            entity.ToTable("Prostorija");

            entity.Property(e => e.ProstorijaId).HasColumnName("prostorija_id");
            entity.Property(e => e.NazivPr)
                .HasMaxLength(20)
                .HasColumnName("nazivPr");
        });

        modelBuilder.Entity<Stanje>(entity =>
        {
            entity.HasKey(e => new { e.ProizvodId, e.LokacijaId });

            entity.ToTable("Stanje");

            entity.Property(e => e.ProizvodId).HasColumnName("proizvod_id");
            entity.Property(e => e.LokacijaId).HasColumnName("lokacija_id");
            entity.Property(e => e.Stanje1).HasColumnName("stanje");

            entity.HasOne(d => d.Lokacija).WithMany(p => p.Stanjes)
                .HasForeignKey(d => d.LokacijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stanje_Lokacija");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.Stanjes)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stanje_Proizvod");
        });

        modelBuilder.Entity<StavkaPorudzbine>(entity =>
        {
            entity.HasKey(e => new { e.ProizvodId, e.PorudzbinaId });

            entity.ToTable("Stavka_Porudzbine");

            entity.Property(e => e.ProizvodId).HasColumnName("proizvod_id");
            entity.Property(e => e.PorudzbinaId).HasColumnName("porudzbina_id");
            entity.Property(e => e.Cena).HasColumnName("cena");
            entity.Property(e => e.Kolicina).HasColumnName("kolicina");

            entity.HasOne(d => d.Porudzbina).WithMany(p => p.StavkaPorudzbines)
                .HasForeignKey(d => d.PorudzbinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stavka_Porudzbine_Porudzbina");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.StavkaPorudzbines)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stavka_Porudzbine_Proizvod");
        });

        modelBuilder.Entity<Uloga>(entity =>
        {
            entity.HasKey(e => e.UlogaId).HasName("PK__Uloga__03C8E0D88F2430E4");

            entity.ToTable("Uloga");

            entity.Property(e => e.UlogaId).HasColumnName("uloga_id");
            entity.Property(e => e.UlogaNaziv)
                .HasMaxLength(20)
                .HasColumnName("uloga_naziv");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
