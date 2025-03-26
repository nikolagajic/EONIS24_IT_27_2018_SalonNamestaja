using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.DTO.KategorijaDTO;

namespace ERP_SalonNamestaja.DTO.ProstorijaDTO
{
    public class GetProstorijaDto
    {
        public int ProstorijaId { get; set; }
        public string? NazivPr { get; set; }
        public List<GetKategorijaDto>? Kategorijas { get; set;}
    }
}