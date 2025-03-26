using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ERP_SalonNamestaja.DTO.PorudzbinaDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public class PorudzbinaService : IPorudzbinaService
    {

        private readonly IMapper _mapper;
        private readonly SalonTestContext _context;

        public PorudzbinaService(IMapper mapper, SalonTestContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<ServiceResponse<List<GetPorudzbinaDto>>> AddPorudzbina(AddPorudzbinaDto novaPorudzbina)
        {
            var response = new ServiceResponse<List<GetPorudzbinaDto>>();
            var Porudzbina = _mapper.Map<Porudzbina>(novaPorudzbina);
            _context.Porudzbinas.Add(Porudzbina);
            await _context.SaveChangesAsync();

            response.Data = await _context.Porudzbinas.Select(p => _mapper.Map<GetPorudzbinaDto>(p)).ToListAsync();
            return response;
            
        }

        public async Task<ServiceResponse<List<GetPorudzbinaDto>>> DeletePorudzbina(int id)
        {
            var response = new ServiceResponse<List<GetPorudzbinaDto>>();

            try
            {
                var Porudzbina = await _context.Porudzbinas.FirstOrDefaultAsync(p => p.PorudzbinaId == id);
                if (Porudzbina is null)
                    throw new Exception($"Porudzbina sa id = {id} nije pronadjena");
                _context.Porudzbinas.Remove(Porudzbina);
                await _context.SaveChangesAsync();

                response.Data = await _context.Porudzbinas.Select(p => _mapper.Map<GetPorudzbinaDto>(p)).ToListAsync();

            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetPorudzbinaDto>>> GetAllPorudzbina()
        {
            var response = new ServiceResponse<List<GetPorudzbinaDto>>();
            var dbPorudzbina = await _context.Porudzbinas.Include(p => p.StavkaPorudzbines).ToListAsync();
            response.Data = dbPorudzbina.Select(p => _mapper.Map<GetPorudzbinaDto>(p)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetPorudzbinaDto>> GetPorudzbinaById(int id)
        {
            var response = new ServiceResponse<GetPorudzbinaDto>();
            var Porudzbina = await _context.Porudzbinas.Include(p => p.StavkaPorudzbines).FirstOrDefaultAsync(p => p.PorudzbinaId == id);
            response.Data = _mapper.Map<GetPorudzbinaDto>(Porudzbina);
            return response;
        }

        public async Task<ServiceResponse<GetPorudzbinaDto>> UpdatePorudzbina(UpdatePorudzbinaDto novaPorudzbina)
        {

            var response = new ServiceResponse<GetPorudzbinaDto>();

            try {

            var Porudzbina = await _context.Porudzbinas.FirstOrDefaultAsync(p => p.PorudzbinaId == novaPorudzbina.PorudzbinaId);
            if(Porudzbina is null)
                throw new Exception($"Porudzbina sa id = {novaPorudzbina.PorudzbinaId} nije pronadjena");
            Porudzbina.DatumKreiranja = novaPorudzbina.DatumKreiranja;
            Porudzbina.VremeKreiranja = novaPorudzbina.VremeKreiranja;
            Porudzbina.UkupnaCena = novaPorudzbina.UkupnaCena;
            Porudzbina.AdresaIsporuke = novaPorudzbina.AdresaIsporuke;
            Porudzbina.KorisnikId = Porudzbina.KorisnikId;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetPorudzbinaDto>(Porudzbina);

            }
            catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}