using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.ProizvodDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IProizvodService
    {
        Task<ServiceResponse<List<GetProizvodDto>>> GetAllProizvod();
        Task<ServiceResponse<GetProizvodDto>> GetProizvodById(int id);
        Task<ServiceResponse<List<GetProizvodDto>>> AddProizvod(AddProizvodDto novaProizvod);
        Task<ServiceResponse<GetProizvodDto>> UpdateProizvod(UpdateProizvodDto novaProizvod);
        Task<ServiceResponse<List<GetProizvodDto>>> DeleteProizvod(int id);
    
    }
}