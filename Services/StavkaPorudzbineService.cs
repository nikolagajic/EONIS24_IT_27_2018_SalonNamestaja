using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ERP_SalonNamestaja.DTO.StavkaPorudzbineDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public class StavkaPorudzbineService : IStavkaPorudzbineService
    {

        private readonly IMapper _mapper;
        private readonly SalonTestContext _context;

        public StavkaPorudzbineService(IMapper mapper, SalonTestContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<ServiceResponse<List<GetStavkaPorudzbineDto>>> AddStavkaPorudzbine(AddStavkaPorudzbineDto novaStavkaPorudzbine)
        {
            var response = new ServiceResponse<List<GetStavkaPorudzbineDto>>();
            var StavkaPorudzbine = _mapper.Map<StavkaPorudzbine>(novaStavkaPorudzbine);
            _context.StavkaPorudzbines.Add(StavkaPorudzbine);
            await _context.SaveChangesAsync();

            response.Data = await _context.StavkaPorudzbines.Select(p => _mapper.Map<GetStavkaPorudzbineDto>(p)).ToListAsync();
            return response;
            
        }

        public async Task<ServiceResponse<List<GetStavkaPorudzbineDto>>> DeleteStavkaPorudzbine(int proizvodId, int porudzbinaId)
        {
            var response = new ServiceResponse<List<GetStavkaPorudzbineDto>>();

            try
            {
                var StavkaPorudzbine = await _context.StavkaPorudzbines.FirstOrDefaultAsync(p => p.ProizvodId == proizvodId & p.PorudzbinaId == porudzbinaId);
                if (StavkaPorudzbine is null)
                    throw new Exception($"Stavka porudzbine nije pronadjena");
                _context.StavkaPorudzbines.Remove(StavkaPorudzbine);
                await _context.SaveChangesAsync();

                response.Data = await _context.StavkaPorudzbines.Select(p => _mapper.Map<GetStavkaPorudzbineDto>(p)).ToListAsync();

            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetStavkaPorudzbineDto>>> GetAllStavkaPorudzbine()
        {
            var response = new ServiceResponse<List<GetStavkaPorudzbineDto>>();
            var dbStavkaPorudzbine = await _context.StavkaPorudzbines.ToListAsync();
            response.Data = dbStavkaPorudzbine.Select(p => _mapper.Map<GetStavkaPorudzbineDto>(p)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetStavkaPorudzbineDto>> GetStavkaPorudzbineById(int proizvodId, int porudzbinaId)
        {
            var response = new ServiceResponse<GetStavkaPorudzbineDto>();
            var StavkaPorudzbine = await _context.StavkaPorudzbines.FirstOrDefaultAsync(p => p.ProizvodId == proizvodId & p.PorudzbinaId == porudzbinaId);
            response.Data = _mapper.Map<GetStavkaPorudzbineDto>(StavkaPorudzbine);
            return response;
        }

        public async Task<ServiceResponse<GetStavkaPorudzbineDto>> UpdateStavkaPorudzbine(UpdateStavkaPorudzbineDto novaStavkaPorudzbine)
        {

            var response = new ServiceResponse<GetStavkaPorudzbineDto>();

            try {

            var StavkaPorudzbine = await _context.StavkaPorudzbines.FirstOrDefaultAsync(p => p.ProizvodId == novaStavkaPorudzbine.ProizvodId & p.PorudzbinaId == novaStavkaPorudzbine.PorudzbinaId);
            if(StavkaPorudzbine is null)
                throw new Exception("Stavka porudzbine nije pronadjena");
            StavkaPorudzbine.PorudzbinaId = novaStavkaPorudzbine.PorudzbinaId;
            StavkaPorudzbine.ProizvodId = novaStavkaPorudzbine.ProizvodId;
            StavkaPorudzbine.Kolicina = novaStavkaPorudzbine.Kolicina;
            StavkaPorudzbine.Cena = novaStavkaPorudzbine.Cena;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetStavkaPorudzbineDto>(StavkaPorudzbine);

            }
            catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}