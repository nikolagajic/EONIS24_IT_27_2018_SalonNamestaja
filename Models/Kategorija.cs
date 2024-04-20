using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Kategorija
{
    public int KategorijaId { get; set; }

    public string? NazivKat { get; set; }

    public int? ProstorijaId { get; set; }

    public virtual ICollection<Proizvod> Proizvods { get; } = new List<Proizvod>();

    public virtual Prostorija? Prostorija { get; set; }
}
