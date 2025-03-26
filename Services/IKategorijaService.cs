using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.KategorijaDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IKategorijaService
    {
        Task<ServiceResponse<List<GetKategorijaDto>>> GetAllKategorija();
        Task<ServiceResponse<GetKategorijaDto>> GetKategorijaById(int id);
        Task<ServiceResponse<List<GetKategorijaDto>>> AddKategorija(AddKategorijaDto novaKategorija);
        Task<ServiceResponse<GetKategorijaDto>> UpdateKategorija(UpdateKategorijaDto novaKategorija);
        Task<ServiceResponse<List<GetKategorijaDto>>> DeleteKategorija(int id);
    
    }
}