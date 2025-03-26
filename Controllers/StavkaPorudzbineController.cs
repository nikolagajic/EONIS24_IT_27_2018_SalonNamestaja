using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.DTO.StavkaPorudzbineDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;

namespace ERP_SalonNamestaja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StavkaPorudzbineController : ControllerBase
    {
        private readonly IStavkaPorudzbineService _StavkaPorudzbineService;

        public StavkaPorudzbineController(IStavkaPorudzbineService StavkaPorudzbineService){
            _StavkaPorudzbineService = StavkaPorudzbineService;
        }
        [HttpGet]    
        public async Task<ActionResult<ServiceResponse<GetStavkaPorudzbineDto>>> GetStavkaPorudzbine(){
            return Ok(await _StavkaPorudzbineService.GetAllStavkaPorudzbine());
        }

        [HttpGet("{proizvodId}/{porudzbinaId}")]
        public async Task<ActionResult<ServiceResponse<GetStavkaPorudzbineDto>>> GetById(int proizvodId, int porudzbinaId) {
            return Ok(await _StavkaPorudzbineService.GetStavkaPorudzbineById(proizvodId, porudzbinaId));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStavkaPorudzbineDto>>>> AddStavkaPorudzbine(AddStavkaPorudzbineDto StavkaPorudzbine){
            return Ok(await _StavkaPorudzbineService.AddStavkaPorudzbine(StavkaPorudzbine));
        }
        
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetStavkaPorudzbineDto>>>> UpdateStavkaPorudzbine(UpdateStavkaPorudzbineDto StavkaPorudzbine){
            var response = await _StavkaPorudzbineService.UpdateStavkaPorudzbine(StavkaPorudzbine);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{proizvodId}/{porudzbinaId}")]
        public async Task<ActionResult<ServiceResponse<List<GetStavkaPorudzbineDto>>>> DeleteStavkaPorudzbine(int proizvodId, int porudzbinaId) {
            var response = await _StavkaPorudzbineService.DeleteStavkaPorudzbine(proizvodId, porudzbinaId);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }


    }
}