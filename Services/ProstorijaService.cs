using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ERP_SalonNamestaja.DTO.ProstorijaDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public class ProstorijaService : IProstorijaService
    {

        private readonly IMapper _mapper;
        private readonly SalonTestContext _context;

        public ProstorijaService(IMapper mapper, SalonTestContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<ServiceResponse<List<GetProstorijaDto>>> AddProstorija(AddProstorijaDto novaProstorija)
        {
            var response = new ServiceResponse<List<GetProstorijaDto>>();
            var Prostorija = _mapper.Map<Prostorija>(novaProstorija);
            _context.Prostorijas.Add(Prostorija);
            await _context.SaveChangesAsync();

            response.Data = await _context.Prostorijas.Select(p => _mapper.Map<GetProstorijaDto>(p)).ToListAsync();
            return response;
            
        }

        public async Task<ServiceResponse<List<GetProstorijaDto>>> DeleteProstorija(int id)
        {
            var response = new ServiceResponse<List<GetProstorijaDto>>();

            try
            {
                var Prostorija = await _context.Prostorijas.FirstOrDefaultAsync(p => p.ProstorijaId == id);
                if (Prostorija is null)
                    throw new Exception($"Prostorija sa id = {id} nije pronadjena");
                _context.Prostorijas.Remove(Prostorija);
                await _context.SaveChangesAsync();

                response.Data = await _context.Prostorijas.Select(p => _mapper.Map<GetProstorijaDto>(p)).ToListAsync();

            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetProstorijaDto>>> GetAllProstorija()
        {
            var response = new ServiceResponse<List<GetProstorijaDto>>();
            var dbProstorija = await _context.Prostorijas.Include(p => p.Kategorijas).ToListAsync();
            response.Data = dbProstorija.Select(p => _mapper.Map<GetProstorijaDto>(p)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetProstorijaDto>> GetProstorijaById(int id)
        {
            var response = new ServiceResponse<GetProstorijaDto>();
            var Prostorija = await _context.Prostorijas.Include(p => p.Kategorijas).FirstOrDefaultAsync(p => p.ProstorijaId == id);
            response.Data = _mapper.Map<GetProstorijaDto>(Prostorija);
            return response;
        }

        public async Task<ServiceResponse<GetProstorijaDto>> UpdateProstorija(UpdateProstorijaDto novaProstorija)
        {

            var response = new ServiceResponse<GetProstorijaDto>();

            try {

            var Prostorija = await _context.Prostorijas.FirstOrDefaultAsync(p => p.ProstorijaId == novaProstorija.ProstorijaId);
            if(Prostorija is null)
                throw new Exception($"Prostorija sa id = {novaProstorija.ProstorijaId} nije pronadjena");
            Prostorija.NazivPr = novaProstorija.NazivPr;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetProstorijaDto>(Prostorija);

            }
            catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}