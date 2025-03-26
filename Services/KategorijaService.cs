using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ERP_SalonNamestaja.DTO.KategorijaDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public class KategorijaService : IKategorijaService
    {

        private readonly IMapper _mapper;
        private readonly SalonTestContext _context;

        public KategorijaService(IMapper mapper, SalonTestContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<ServiceResponse<List<GetKategorijaDto>>> AddKategorija(AddKategorijaDto novaKategorija)
        {
            var response = new ServiceResponse<List<GetKategorijaDto>>();
            var Kategorija = _mapper.Map<Kategorija>(novaKategorija);
            _context.Kategorijas.Add(Kategorija);
            await _context.SaveChangesAsync();

            response.Data = await _context.Kategorijas.Select(p => _mapper.Map<GetKategorijaDto>(p)).ToListAsync();
            return response;
            
        }

        public async Task<ServiceResponse<List<GetKategorijaDto>>> DeleteKategorija(int id)
        {
            var response = new ServiceResponse<List<GetKategorijaDto>>();

            try
            {
                var Kategorija = await _context.Kategorijas.FirstOrDefaultAsync(p => p.KategorijaId == id);
                if (Kategorija is null)
                    throw new Exception($"Kategorija sa id = {id} nije pronadjena");
                _context.Kategorijas.Remove(Kategorija);
                await _context.SaveChangesAsync();

                response.Data = await _context.Kategorijas.Select(p => _mapper.Map<GetKategorijaDto>(p)).ToListAsync();

            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetKategorijaDto>>> GetAllKategorija()
        {
            var response = new ServiceResponse<List<GetKategorijaDto>>();
            var dbKategorija = await _context.Kategorijas.Include(k => k.Proizvods).ToListAsync();
            response.Data = dbKategorija.Select(p => _mapper.Map<GetKategorijaDto>(p)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetKategorijaDto>> GetKategorijaById(int id)
        {
            var response = new ServiceResponse<GetKategorijaDto>();
            var Kategorija = await _context.Kategorijas.Include(k => k.Proizvods).FirstOrDefaultAsync(p => p.KategorijaId == id);
            response.Data = _mapper.Map<GetKategorijaDto>(Kategorija);
            return response;
        }

        public async Task<ServiceResponse<GetKategorijaDto>> UpdateKategorija(UpdateKategorijaDto novaKategorija)
        {

            var response = new ServiceResponse<GetKategorijaDto>();

            try {

            var Kategorija = await _context.Kategorijas.FirstOrDefaultAsync(p => p.KategorijaId == novaKategorija.KategorijaId);
            if(Kategorija is null)
                throw new Exception($"Kategorija sa id = {novaKategorija.KategorijaId} nije pronadjena");
            Kategorija.NazivKat = novaKategorija.NazivKat;
            Kategorija.ProstorijaId = novaKategorija.ProstorijaId;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetKategorijaDto>(Kategorija);

            }
            catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}