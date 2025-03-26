using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.ProstorijaDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IProstorijaService
    {
        Task<ServiceResponse<List<GetProstorijaDto>>> GetAllProstorija();
        Task<ServiceResponse<GetProstorijaDto>> GetProstorijaById(int id);
        Task<ServiceResponse<List<GetProstorijaDto>>> AddProstorija(AddProstorijaDto novaProstorija);
        Task<ServiceResponse<GetProstorijaDto>> UpdateProstorija(UpdateProstorijaDto novaProstorija);
        Task<ServiceResponse<List<GetProstorijaDto>>> DeleteProstorija(int id);
    
    }
}