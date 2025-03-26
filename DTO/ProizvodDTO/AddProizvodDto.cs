using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.ProizvodDTO
{
    public class AddProizvodDto
    {
        public string SifraProizvod { get; set; } = null!;

        public double? Cena { get; set; }

        public string? Opis { get; set; }

        public string? Materijal { get; set; }

        public string? Naziv { get; set; }

        public int? KategorijaId { get; set; }

        public int? ProizvodjacId { get; set; }

    }
}