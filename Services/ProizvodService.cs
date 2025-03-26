using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ERP_SalonNamestaja.DTO.ProizvodDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public class ProizvodService : IProizvodService
    {

        private readonly IMapper _mapper;
        private readonly SalonTestContext _context;

        public ProizvodService(IMapper mapper, SalonTestContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<ServiceResponse<List<GetProizvodDto>>> AddProizvod(AddProizvodDto novaProizvod)
        {
            var response = new ServiceResponse<List<GetProizvodDto>>();
            var Proizvod = _mapper.Map<Proizvod>(novaProizvod);
            _context.Proizvods.Add(Proizvod);
            await _context.SaveChangesAsync();

            response.Data = await _context.Proizvods.Select(p => _mapper.Map<GetProizvodDto>(p)).ToListAsync();
            return response;
            
        }

        public async Task<ServiceResponse<List<GetProizvodDto>>> DeleteProizvod(int id)
        {
            var response = new ServiceResponse<List<GetProizvodDto>>();

            try
            {
                var Proizvod = await _context.Proizvods.FirstOrDefaultAsync(p => p.ProizvodId == id);
                if (Proizvod is null)
                    throw new Exception($"Proizvod sa id = {id} nije pronadjena");
                _context.Proizvods.Remove(Proizvod);
                await _context.SaveChangesAsync();

                response.Data = await _context.Proizvods.Select(p => _mapper.Map<GetProizvodDto>(p)).ToListAsync();

            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetProizvodDto>>> GetAllProizvod()
        {
            var response = new ServiceResponse<List<GetProizvodDto>>();
            var dbProizvod = await _context.Proizvods.Include(p => p.Stanjes).Include(p => p.StavkaPorudzbines).ToListAsync();
            response.Data = dbProizvod.Select(p => _mapper.Map<GetProizvodDto>(p)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetProizvodDto>> GetProizvodById(int id)
        {
            var response = new ServiceResponse<GetProizvodDto>();
            var Proizvod = await _context.Proizvods.Include(p => p.Stanjes).Include(p => p.StavkaPorudzbines).FirstOrDefaultAsync(p => p.ProizvodId == id);
            response.Data = _mapper.Map<GetProizvodDto>(Proizvod);
            return response;
        }

        public async Task<ServiceResponse<GetProizvodDto>> UpdateProizvod(UpdateProizvodDto novaProizvod)
        {

            var response = new ServiceResponse<GetProizvodDto>();

            try {

            var Proizvod = await _context.Proizvods.FirstOrDefaultAsync(p => p.ProizvodId == novaProizvod.ProizvodId);
            if(Proizvod is null)
                throw new Exception($"Proizvod sa id = {novaProizvod.ProizvodId} nije pronadjena");
            Proizvod.SifraProizvod = novaProizvod.SifraProizvod;
            Proizvod.Cena = novaProizvod.Cena;
            Proizvod.Opis = novaProizvod.Opis;
            Proizvod.Materijal = novaProizvod.Materijal;
            Proizvod.Naziv = novaProizvod.Naziv;
            Proizvod.KategorijaId = novaProizvod.KategorijaId;
            Proizvod.ProizvodjacId = novaProizvod.ProizvodjacId;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetProizvodDto>(Proizvod);

            }
            catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}