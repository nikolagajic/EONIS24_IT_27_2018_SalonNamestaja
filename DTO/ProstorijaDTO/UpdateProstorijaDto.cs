using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.ProstorijaDTO
{
    public class UpdateProstorijaDto
    {
        public int ProstorijaId { get; set; }
        public string? NazivPr { get; set; }
    }
}