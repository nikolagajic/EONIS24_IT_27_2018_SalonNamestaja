using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.Prostorija
{
    public class GetProstorijaDto
    {
        public int ProstorijaId { get; set; }
        public string? NazivPr { get; set; }
        public virtual ICollection<Kategorija> Kategorijas { get; } = new List<Kategorija>();
    }
}