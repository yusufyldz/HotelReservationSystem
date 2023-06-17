using HotelReservation.Business.Concrete;
using HotelReservation.Model.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using HotelReservation.Model.Models;
using HotelReservation.Data.Concrete;

namespace HotelReservation.Business.Abstract
{
    public class AdminBusinessService : IAdminBusinessService
    {
        private readonly IConfiguration _configuration;
        private readonly IAdminRepository _adminRepository;
        public AdminBusinessService(IConfiguration configuration, IAdminRepository adminRepository)
        {
            _configuration = configuration;
            _adminRepository = adminRepository;
        }
        public async Task<UserLoginDto> Login(string EmailAddress, string Password)
        {
            try
            {


                User user = await _adminRepository.GetAsync<User>(x => x.email_address == EmailAddress.Trim() && x.password == Password.Trim());
                if (user == null) throw new Exception("User Not Found");

                var token = await CreateToken(user);

                return new UserLoginDto { email_address = user.email_address, user_name = user.full_name, token = token };
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        private async Task<string> CreateToken(User user)
        {
            int minutes = int.Parse(_configuration.GetSection("Token:AccessTokenExpiration").Value);
            var accessTokenExpiration = DateTime.Now.AddMinutes(minutes);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Token:AccessTokenExpiration").Value));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                _configuration.GetSection("Token:Issuer").Value,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: await GetClaims(user),
                signingCredentials: signingCredentials));
            return token;

        }
        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
            new Claim(ClaimTypes.Name,user.full_name),
            new Claim(JwtRegisteredClaimNames.Email, user.email_address),
            new Claim("hotel_id",user.hote_id.ToString()),
            new Claim(ClaimTypes.Role,"Admin"),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };


            claims.Add(new Claim(JwtRegisteredClaimNames.Aud, _configuration.GetSection("Token:Audience").Value));


            return claims;
        }
    }
}
