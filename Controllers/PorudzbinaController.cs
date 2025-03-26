using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.DTO.PorudzbinaDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;

namespace ERP_SalonNamestaja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PorudzbinaController : ControllerBase
    {
        private readonly IPorudzbinaService _PorudzbinaService;

        public PorudzbinaController(IPorudzbinaService PorudzbinaService){
            _PorudzbinaService = PorudzbinaService;
        }
        [HttpGet]    
        public async Task<ActionResult<ServiceResponse<GetPorudzbinaDto>>> GetPorudzbina(){
            return Ok(await _PorudzbinaService.GetAllPorudzbina());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPorudzbinaDto>>> GetById(int id) {
            return Ok(await _PorudzbinaService.GetPorudzbinaById(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPorudzbinaDto>>>> AddPorudzbina(AddPorudzbinaDto Porudzbina){
            return Ok(await _PorudzbinaService.AddPorudzbina(Porudzbina));
        }
        
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetPorudzbinaDto>>>> UpdatePorudzbina(UpdatePorudzbinaDto Porudzbina){
            var response = await _PorudzbinaService.UpdatePorudzbina(Porudzbina);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPorudzbinaDto>>>> DeletePorudzbina(int id) {
            var response = await _PorudzbinaService.DeletePorudzbina(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }


    }
}