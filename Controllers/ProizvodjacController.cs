using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.DTO.ProizvodjacDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;

namespace ERP_SalonNamestaja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProizvodjacController : ControllerBase
    {
        private readonly IProizvodjacService _ProizvodjacService;

        public ProizvodjacController(IProizvodjacService ProizvodjacService){
            _ProizvodjacService = ProizvodjacService;
        }
        [HttpGet]    
        public async Task<ActionResult<ServiceResponse<GetProizvodjacDto>>> GetProizvodjac(){
            return Ok(await _ProizvodjacService.GetAllProizvodjac());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProizvodjacDto>>> GetById(int id) {
            return Ok(await _ProizvodjacService.GetProizvodjacById(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProizvodjacDto>>>> AddProizvodjac(AddProizvodjacDto Proizvodjac){
            return Ok(await _ProizvodjacService.AddProizvodjac(Proizvodjac));
        }
        
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetProizvodjacDto>>>> UpdateProizvodjac(UpdateProizvodjacDto Proizvodjac){
            var response = await _ProizvodjacService.UpdateProizvodjac(Proizvodjac);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetProizvodjacDto>>>> DeleteProizvodjac(int id) {
            var response = await _ProizvodjacService.DeleteProizvodjac(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }


    }
}