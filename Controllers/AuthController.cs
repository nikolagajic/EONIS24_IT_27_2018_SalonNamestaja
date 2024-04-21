using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;
using ERP_SalonNamestaja.DTO.Korisnik;

namespace ERP_SalonNamestaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(KorisnikRegisterDto request)
        {   
            var response = await _authRepository.Register(
                new Korisnik {Username = request.Username }, request.Paswword
            );
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
            
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(KorisnikRegisterDto request)
        {   
            var response = await _authRepository.Login(request.Username, request.Paswword);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
            
        }
        
    }
}