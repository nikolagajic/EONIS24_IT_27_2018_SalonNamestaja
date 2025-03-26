using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.LokacijaDTO
{
    public class GetLokacijaDto
    {
        public int LokacijaId { get; set; }

        public string? Grad { get; set; }

        public string? Adresa { get; set; }

        public List<Stanje>? Stanjes { get; set;}

    }
}