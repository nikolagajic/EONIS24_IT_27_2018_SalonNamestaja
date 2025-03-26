using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.DTO.LokacijaDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;

namespace ERP_SalonNamestaja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LokacijaController : ControllerBase
    {
        private readonly ILokacijaService _LokacijaService;

        public LokacijaController(ILokacijaService LokacijaService){
            _LokacijaService = LokacijaService;
        }
        [HttpGet]    
        public async Task<ActionResult<ServiceResponse<GetLokacijaDto>>> GetLokacija(){
            return Ok(await _LokacijaService.GetAllLokacija());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetLokacijaDto>>> GetById(int id) {
            return Ok(await _LokacijaService.GetLokacijaById(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetLokacijaDto>>>> AddLokacija(AddLokacijaDto Lokacija){
            return Ok(await _LokacijaService.AddLokacija(Lokacija));
        }
        
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetLokacijaDto>>>> UpdateLokacija(UpdateLokacijaDto Lokacija){
            var response = await _LokacijaService.UpdateLokacija(Lokacija);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetLokacijaDto>>>> DeleteLokacija(int id) {
            var response = await _LokacijaService.DeleteLokacija(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }


    }
}