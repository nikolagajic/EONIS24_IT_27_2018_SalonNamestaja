using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.DTO.StanjeDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;

namespace ERP_SalonNamestaja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StanjeController : ControllerBase
    {
        private readonly IStanjeService _StanjeService;

        public StanjeController(IStanjeService StanjeService){
            _StanjeService = StanjeService;
        }
        [HttpGet]    
        public async Task<ActionResult<ServiceResponse<GetStanjeDto>>> GetStanje(){
            return Ok(await _StanjeService.GetAllStanje());
        }

        [HttpGet("{id}/{id2}")]
        public async Task<ActionResult<ServiceResponse<GetStanjeDto>>> GetById(int id, int id2) {
            return Ok(await _StanjeService.GetStanjeById(id, id2));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStanjeDto>>>> AddStanje(AddStanjeDto Stanje){
            return Ok(await _StanjeService.AddStanje(Stanje));
        }
        
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetStanjeDto>>>> UpdateStanje(UpdateStanjeDto Stanje){
            var response = await _StanjeService.UpdateStanje(Stanje);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}/{id2}")]
        public async Task<ActionResult<ServiceResponse<List<GetStanjeDto>>>> DeleteStanje(int id, int id2) {
            var response = await _StanjeService.DeleteStanje(id, id2);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }


    }
}