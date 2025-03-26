using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ERP_SalonNamestaja.DTO.ProizvodjacDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public class ProizvodjacService : IProizvodjacService
    {

        private readonly IMapper _mapper;
        private readonly SalonTestContext _context;

        public ProizvodjacService(IMapper mapper, SalonTestContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<ServiceResponse<List<GetProizvodjacDto>>> AddProizvodjac(AddProizvodjacDto novaProizvodjac)
        {
            var response = new ServiceResponse<List<GetProizvodjacDto>>();
            var Proizvodjac = _mapper.Map<Proizvodjac>(novaProizvodjac);
            _context.Proizvodjacs.Add(Proizvodjac);
            await _context.SaveChangesAsync();

            response.Data = await _context.Proizvodjacs.Select(p => _mapper.Map<GetProizvodjacDto>(p)).ToListAsync();
            return response;
            
        }

        public async Task<ServiceResponse<List<GetProizvodjacDto>>> DeleteProizvodjac(int id)
        {
            var response = new ServiceResponse<List<GetProizvodjacDto>>();

            try
            {
                var Proizvodjac = await _context.Proizvodjacs.FirstOrDefaultAsync(p => p.ProizvodjacId == id);
                if (Proizvodjac is null)
                    throw new Exception($"Proizvodjac sa id = {id} nije pronadjena");
                _context.Proizvodjacs.Remove(Proizvodjac);
                await _context.SaveChangesAsync();

                response.Data = await _context.Proizvodjacs.Select(p => _mapper.Map<GetProizvodjacDto>(p)).ToListAsync();

            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetProizvodjacDto>>> GetAllProizvodjac()
        {
            var response = new ServiceResponse<List<GetProizvodjacDto>>();
            var dbProizvodjac = await _context.Proizvodjacs.Include(p => p.Proizvods).ToListAsync();
            response.Data = dbProizvodjac.Select(p => _mapper.Map<GetProizvodjacDto>(p)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetProizvodjacDto>> GetProizvodjacById(int id)
        {
            var response = new ServiceResponse<GetProizvodjacDto>();
            var Proizvodjac = await _context.Proizvodjacs.Include(p => p.Proizvods).FirstOrDefaultAsync(p => p.ProizvodjacId == id);
            response.Data = _mapper.Map<GetProizvodjacDto>(Proizvodjac);
            return response;
        }

        public async Task<ServiceResponse<GetProizvodjacDto>> UpdateProizvodjac(UpdateProizvodjacDto novaProizvodjac)
        {

            var response = new ServiceResponse<GetProizvodjacDto>();

            try {

            var Proizvodjac = await _context.Proizvodjacs.FirstOrDefaultAsync(p => p.ProizvodjacId == novaProizvodjac.ProizvodjacId);
            if(Proizvodjac is null)
                throw new Exception($"Proizvodjac sa id = {novaProizvodjac.ProizvodjacId} nije pronadjena");
            Proizvodjac.Naziv = novaProizvodjac.Naziv;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetProizvodjacDto>(Proizvodjac);

            }
            catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}