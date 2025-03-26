using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.PorudzbinaDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IPorudzbinaService
    {
        Task<ServiceResponse<List<GetPorudzbinaDto>>> GetAllPorudzbina();
        Task<ServiceResponse<GetPorudzbinaDto>> GetPorudzbinaById(int id);
        Task<ServiceResponse<List<GetPorudzbinaDto>>> AddPorudzbina(AddPorudzbinaDto novaPorudzbina);
        Task<ServiceResponse<GetPorudzbinaDto>> UpdatePorudzbina(UpdatePorudzbinaDto novaPorudzbina);
        Task<ServiceResponse<List<GetPorudzbinaDto>>> DeletePorudzbina(int id);
    
    }
}