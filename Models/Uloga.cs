using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Uloga
{
    public int UlogaId { get; set; }

    public string? UlogaNaziv { get; set; }

    public virtual ICollection<Korisnik> Korisniks { get; } = new List<Korisnik>();
}
