using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Prostorija
{
    public int ProstorijaId { get; set; }

    public string? NazivPr { get; set; }

    public virtual ICollection<Kategorija> Kategorijas { get; } = new List<Kategorija>();
}
