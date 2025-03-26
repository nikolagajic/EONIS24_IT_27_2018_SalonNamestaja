using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ERP_SalonNamestaja.DTO.StanjeDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public class StanjeService : IStanjeService
    {

        private readonly IMapper _mapper;
        private readonly SalonTestContext _context;

        public StanjeService(IMapper mapper, SalonTestContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<ServiceResponse<List<GetStanjeDto>>> AddStanje(AddStanjeDto novaStanje)
        {
            var response = new ServiceResponse<List<GetStanjeDto>>();
            var Stanje = _mapper.Map<Stanje>(novaStanje);
            _context.Stanjes.Add(Stanje);
            await _context.SaveChangesAsync();

            response.Data = await _context.Stanjes.Select(p => _mapper.Map<GetStanjeDto>(p)).ToListAsync();
            return response;
            
        }

        public async Task<ServiceResponse<List<GetStanjeDto>>> DeleteStanje(int proizvodId, int lokacijaId)
        {
            var response = new ServiceResponse<List<GetStanjeDto>>();

            try
            {
                var Stanje = await _context.Stanjes.FirstOrDefaultAsync(p => p.ProizvodId == proizvodId & p.LokacijaId == lokacijaId);
                if (Stanje is null)
                    throw new Exception("Stanje nije pronadjeno");
                _context.Stanjes.Remove(Stanje);
                await _context.SaveChangesAsync();

                response.Data = await _context.Stanjes.Select(p => _mapper.Map<GetStanjeDto>(p)).ToListAsync();

            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetStanjeDto>>> GetAllStanje()
        {
            var response = new ServiceResponse<List<GetStanjeDto>>();
            var dbStanje = await _context.Stanjes.ToListAsync();
            response.Data = dbStanje.Select(p => _mapper.Map<GetStanjeDto>(p)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetStanjeDto>> GetStanjeById(int proizvodId, int lokacijaId)
        {
            var response = new ServiceResponse<GetStanjeDto>();
            var Stanje = await _context.Stanjes.FirstOrDefaultAsync(p => p.ProizvodId == proizvodId & p.LokacijaId == lokacijaId) ;
            response.Data = _mapper.Map<GetStanjeDto>(Stanje);
            return response;
        }

        public async Task<ServiceResponse<GetStanjeDto>> UpdateStanje(UpdateStanjeDto novaStanje)
        {

            var response = new ServiceResponse<GetStanjeDto>();

            try {

            var Stanje = await _context.Stanjes.FirstOrDefaultAsync(p => p.ProizvodId == novaStanje.ProizvodId & p.LokacijaId == novaStanje.LokacijaId);
            if(Stanje is null)
                throw new Exception("Stanje nije pronadjeno");
            Stanje.LokacijaId = novaStanje.LokacijaId;
            Stanje.ProizvodId = novaStanje.ProizvodId;
            Stanje.Stanje1 = novaStanje.Stanje1;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetStanjeDto>(Stanje);

            }
            catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}