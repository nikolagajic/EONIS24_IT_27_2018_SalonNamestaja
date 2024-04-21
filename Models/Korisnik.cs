using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Korisnik
{
    public int KorisnikId { get; set; }

    public string? Username { get; set; }

    public byte[]? PasswordHash { get; set; }

    public int? UlogaId { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public string? Adresa { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public virtual ICollection<Porudzbina> Porudzbinas { get; } = new List<Porudzbina>();

    public virtual Uloga? Uloga { get; set; }
}
