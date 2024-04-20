using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Stanje
{
    public int ProizvodId { get; set; }

    public int LokacijaId { get; set; }

    public int? Stanje1 { get; set; }

    public virtual Lokacija Lokacija { get; set; } = null!;

    public virtual Proizvod Proizvod { get; set; } = null!;
}
