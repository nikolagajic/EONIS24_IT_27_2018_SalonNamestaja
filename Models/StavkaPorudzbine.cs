using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class StavkaPorudzbine
{
    public int ProizvodId { get; set; }

    public int PorudzbinaId { get; set; }

    public int? Kolicina { get; set; }

    public double? Cena { get; set; }

    public virtual Porudzbina Porudzbina { get; set; } = null!;

    public virtual Proizvod Proizvod { get; set; } = null!;
}
