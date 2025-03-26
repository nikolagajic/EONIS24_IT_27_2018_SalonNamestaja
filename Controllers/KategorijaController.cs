using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.DTO.KategorijaDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;

namespace ERP_SalonNamestaja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class KategorijaController : ControllerBase
    {
        private readonly IKategorijaService _KategorijaService;

        public KategorijaController(IKategorijaService KategorijaService){
            _KategorijaService = KategorijaService;
        }
        [HttpGet]    
        public async Task<ActionResult<ServiceResponse<GetKategorijaDto>>> GetKategorija(){
            return Ok(await _KategorijaService.GetAllKategorija());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetKategorijaDto>>> GetById(int id) {
            return Ok(await _KategorijaService.GetKategorijaById(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetKategorijaDto>>>> AddKategorija(AddKategorijaDto Kategorija){
            return Ok(await _KategorijaService.AddKategorija(Kategorija));
        }
        
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetKategorijaDto>>>> UpdateKategorija(UpdateKategorijaDto Kategorija){
            var response = await _KategorijaService.UpdateKategorija(Kategorija);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetKategorijaDto>>>> DeleteKategorija(int id) {
            var response = await _KategorijaService.DeleteKategorija(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }


    }
}