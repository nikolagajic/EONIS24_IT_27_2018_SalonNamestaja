using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.LokacijaDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface ILokacijaService
    {
        Task<ServiceResponse<List<GetLokacijaDto>>> GetAllLokacija();
        Task<ServiceResponse<GetLokacijaDto>> GetLokacijaById(int id);
        Task<ServiceResponse<List<GetLokacijaDto>>> AddLokacija(AddLokacijaDto novaLokacija);
        Task<ServiceResponse<GetLokacijaDto>> UpdateLokacija(UpdateLokacijaDto novaLokacija);
        Task<ServiceResponse<List<GetLokacijaDto>>> DeleteLokacija(int id);
    
    }
}