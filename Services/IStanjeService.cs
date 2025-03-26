using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.StanjeDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IStanjeService
    {
        Task<ServiceResponse<List<GetStanjeDto>>> GetAllStanje();
        Task<ServiceResponse<GetStanjeDto>> GetStanjeById(int proizvodId, int lokacijaId);
        Task<ServiceResponse<List<GetStanjeDto>>> AddStanje(AddStanjeDto novaStanje);
        Task<ServiceResponse<GetStanjeDto>> UpdateStanje(UpdateStanjeDto novaStanje);
        Task<ServiceResponse<List<GetStanjeDto>>> DeleteStanje(int proizvodId, int lokacijaId);
    
    }
}