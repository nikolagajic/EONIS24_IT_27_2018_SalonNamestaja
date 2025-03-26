using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.DTO.ProstorijaDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;

namespace ERP_SalonNamestaja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProstorijaController : ControllerBase
    {
        private readonly IProstorijaService _prostorijaService;

        public ProstorijaController(IProstorijaService prostorijaService){
            _prostorijaService = prostorijaService;
        }
        [HttpGet]    
        public async Task<ActionResult<ServiceResponse<GetProstorijaDto>>> GetProstorija(){
            return Ok(await _prostorijaService.GetAllProstorija());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProstorijaDto>>> GetById(int id) {
            return Ok(await _prostorijaService.GetProstorijaById(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProstorijaDto>>>> AddProstorija(AddProstorijaDto prostorija){
            return Ok(await _prostorijaService.AddProstorija(prostorija));
        }
        
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetProstorijaDto>>>> UpdateProstorija(UpdateProstorijaDto prostorija){
            var response = await _prostorijaService.UpdateProstorija(prostorija);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetProstorijaDto>>>> DeleteProstorija(int id) {
            var response = await _prostorijaService.DeleteProstorija(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }


    }
}