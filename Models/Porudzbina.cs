using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Porudzbina
{
    public int PorudzbinaId { get; set; }

    public DateTime? DatumKreiranja { get; set; }

    public TimeSpan? VremeKreiranja { get; set; }

    public double? UkupnaCena { get; set; }

    public string? AdresaIsporuke { get; set; }

    public int KorisnikId { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual ICollection<StavkaPorudzbine> StavkaPorudzbines { get; } = new List<StavkaPorudzbine>();
}
