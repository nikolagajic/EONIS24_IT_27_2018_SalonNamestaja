using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.StavkaPorudzbineDTO
{
    public class UpdateStavkaPorudzbineDto
    {
        public int ProizvodId { get; set; }

        public int PorudzbinaId { get; set; }

        public int? Kolicina { get; set; }

        public double? Cena { get; set; }
    }
}