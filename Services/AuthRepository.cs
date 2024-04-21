using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ERP_SalonNamestaja.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SalonTestContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(SalonTestContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var korisnik = await _context.Korisniks.FirstOrDefaultAsync(k => k.Username.Equals(username));
            if (korisnik is null)
            {
                response.Success = false;
                response.Message = "Korisnik nije pronadjen";
            }
            else if (!VerifyPasswordHash(password, korisnik.PasswordHash, korisnik.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Pogresna lozinka";
            }
            else
            {
                response.Data = CreateToken(korisnik);
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(Korisnik korisnik, string password)
        {
            var response = new ServiceResponse<int>();
            if (await UserExists(korisnik.Username))
            {
                response.Success = false;
                response.Message = "Korisnik vec postoji";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            korisnik.PasswordHash = passwordHash;
            korisnik.PasswordSalt = passwordSalt;

            _context.Korisniks.Add(korisnik);
            await _context.SaveChangesAsync();
            response.Data = korisnik.KorisnikId;
            return response;            
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Korisniks.AnyAsync(k => k.Username == username))
                return true;
            return false;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(Korisnik korisnik)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, korisnik.KorisnikId.ToString()),
                new Claim(ClaimTypes.Name, korisnik.Username)
            };

            var appSettingsToken = _configuration.GetSection("Appsettings:Token").Value;
            if(appSettingsToken is null)
                throw new Exception("Appsettings Token is null");
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = credentials            
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);

        }
    }
}