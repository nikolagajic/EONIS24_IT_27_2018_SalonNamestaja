using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Korisnik korisnik, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);

    }
}