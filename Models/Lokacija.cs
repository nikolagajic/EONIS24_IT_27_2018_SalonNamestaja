using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Lokacija
{
    public int LokacijaId { get; set; }

    public string? Grad { get; set; }

    public string? Adresa { get; set; }

    public virtual ICollection<Stanje> Stanjes { get; } = new List<Stanje>();
}
