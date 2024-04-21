using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_SalonNamestaja.DTO.Korisnik
{
    public class KorisnikLoginDto
    {
        public string Username {get; set;} = string.Empty;

        public string Paswword {get; set;} = string.Empty;
    }
}