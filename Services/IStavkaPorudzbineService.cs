using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.StavkaPorudzbineDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IStavkaPorudzbineService
    {
        Task<ServiceResponse<List<GetStavkaPorudzbineDto>>> GetAllStavkaPorudzbine();
        Task<ServiceResponse<GetStavkaPorudzbineDto>> GetStavkaPorudzbineById(int proizvodId, int porudzbinaId);
        Task<ServiceResponse<List<GetStavkaPorudzbineDto>>> AddStavkaPorudzbine(AddStavkaPorudzbineDto novaStavkaPorudzbine);
        Task<ServiceResponse<GetStavkaPorudzbineDto>> UpdateStavkaPorudzbine(UpdateStavkaPorudzbineDto novaStavkaPorudzbine);
        Task<ServiceResponse<List<GetStavkaPorudzbineDto>>> DeleteStavkaPorudzbine(int proizvodId, int porudzbinaId);
    
    }
}