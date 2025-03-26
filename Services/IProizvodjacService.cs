using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.ProizvodjacDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IProizvodjacService
    {
        Task<ServiceResponse<List<GetProizvodjacDto>>> GetAllProizvodjac();
        Task<ServiceResponse<GetProizvodjacDto>> GetProizvodjacById(int id);
        Task<ServiceResponse<List<GetProizvodjacDto>>> AddProizvodjac(AddProizvodjacDto novaProizvodjac);
        Task<ServiceResponse<GetProizvodjacDto>> UpdateProizvodjac(UpdateProizvodjacDto novaProizvodjac);
        Task<ServiceResponse<List<GetProizvodjacDto>>> DeleteProizvodjac(int id);
    
    }
}