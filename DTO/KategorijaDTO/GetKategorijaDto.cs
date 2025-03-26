using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.KategorijaDTO
{
    public class GetKategorijaDto
    {
        public int KategorijaId { get; set; }

        public string? NazivKat { get; set; }

        public int? ProstorijaId { get; set; }

        public List<Proizvod>? Proizvods { get; set;}

    }
}