using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ERP_SalonNamestaja.DTO.LokacijaDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public class LokacijaService : ILokacijaService
    {

        private readonly IMapper _mapper;
        private readonly SalonTestContext _context;

        public LokacijaService(IMapper mapper, SalonTestContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<ServiceResponse<List<GetLokacijaDto>>> AddLokacija(AddLokacijaDto novaLokacija)
        {
            var response = new ServiceResponse<List<GetLokacijaDto>>();
            var Lokacija = _mapper.Map<Lokacija>(novaLokacija);
            _context.Lokacijas.Add(Lokacija);
            await _context.SaveChangesAsync();

            response.Data = await _context.Lokacijas.Select(p => _mapper.Map<GetLokacijaDto>(p)).ToListAsync();
            return response;
            
        }

        public async Task<ServiceResponse<List<GetLokacijaDto>>> DeleteLokacija(int id)
        {
            var response = new ServiceResponse<List<GetLokacijaDto>>();

            try
            {
                var Lokacija = await _context.Lokacijas.FirstOrDefaultAsync(p => p.LokacijaId == id);
                if (Lokacija is null)
                    throw new Exception($"Lokacija sa id = {id} nije pronadjena");
                _context.Lokacijas.Remove(Lokacija);
                await _context.SaveChangesAsync();

                response.Data = await _context.Lokacijas.Select(p => _mapper.Map<GetLokacijaDto>(p)).ToListAsync();

            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetLokacijaDto>>> GetAllLokacija()
        {
            var response = new ServiceResponse<List<GetLokacijaDto>>();
            var dbLokacija = await _context.Lokacijas.Include(l => l.Stanjes).ToListAsync();
            response.Data = dbLokacija.Select(p => _mapper.Map<GetLokacijaDto>(p)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetLokacijaDto>> GetLokacijaById(int id)
        {
            var response = new ServiceResponse<GetLokacijaDto>();
            var Lokacija = await _context.Lokacijas.Include(l => l.Stanjes).FirstOrDefaultAsync(p => p.LokacijaId == id);
            response.Data = _mapper.Map<GetLokacijaDto>(Lokacija);
            return response;
        }

        public async Task<ServiceResponse<GetLokacijaDto>> UpdateLokacija(UpdateLokacijaDto novaLokacija)
        {

            var response = new ServiceResponse<GetLokacijaDto>();

            try {

            var Lokacija = await _context.Lokacijas.FirstOrDefaultAsync(p => p.LokacijaId == novaLokacija.LokacijaId);
            if(Lokacija is null)
                throw new Exception($"Lokacija sa id = {novaLokacija.LokacijaId} nije pronadjena");
            Lokacija.Grad = novaLokacija.Grad;
            Lokacija.Adresa = novaLokacija.Adresa;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetLokacijaDto>(Lokacija);

            }
            catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}