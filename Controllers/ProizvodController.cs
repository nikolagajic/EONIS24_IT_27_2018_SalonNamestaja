using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.DTO.ProizvodDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;

namespace ERP_SalonNamestaja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProizvodController : ControllerBase
    {
        private readonly IProizvodService _ProizvodService;

        public ProizvodController(IProizvodService ProizvodService){
            _ProizvodService = ProizvodService;
        }
        [HttpGet]    
        public async Task<ActionResult<ServiceResponse<GetProizvodDto>>> GetProizvod(){
            return Ok(await _ProizvodService.GetAllProizvod());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProizvodDto>>> GetById(int id) {
            return Ok(await _ProizvodService.GetProizvodById(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProizvodDto>>>> AddProizvod(AddProizvodDto Proizvod){
            return Ok(await _ProizvodService.AddProizvod(Proizvod));
        }
        
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetProizvodDto>>>> UpdateProizvod(UpdateProizvodDto Proizvod){
            var response = await _ProizvodService.UpdateProizvod(Proizvod);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetProizvodDto>>>> DeleteProizvod(int id) {
            var response = await _ProizvodService.DeleteProizvod(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }


    }
}