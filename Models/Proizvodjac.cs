using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Proizvodjac
{
    public int ProizvodjacId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Proizvod> Proizvods { get; } = new List<Proizvod>();
}
