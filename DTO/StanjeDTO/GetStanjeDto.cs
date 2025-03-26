using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.StanjeDTO
{
    public class GetStanjeDto
    {
        public int ProizvodId { get; set; }

        public int LokacijaId { get; set; }

        public int? Stanje1 { get; set; }
    }
}