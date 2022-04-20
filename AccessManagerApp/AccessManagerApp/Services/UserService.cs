using AccessManagerApp.Data;
using AccessManagerApp.DTOs;
using AccessManagerApp.Helpers;
using AccessManagerApp.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagerApp.Services
{
    public class UserService
    {
        private readonly DbContextAccessManager _dbContextAccessManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserService(DbContextAccessManager dbContextAccessManager, IMapper mapper, IConfiguration configuration)
        {
            _dbContextAccessManager = dbContextAccessManager;
            _mapper = mapper;
            _config = configuration;
        }

        public async Task<JwtTokenSettingsDTO> Authenticate(UserLoginDTO model) 
        {
            User user = await _dbContextAccessManager.Users.FirstOrDefaultAsync(f => f.Username == model.Username); 

            if (user == null)
                return null;

            if (!CheckPassword(user.Password, model.Password))            
                return null;

            return GenerateToken(model);                        

        }

        public JwtTokenSettingsDTO GenerateToken(UserLoginDTO user)
        {           
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),                   
                new Claim("Name", user.Username),
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
              _config["JwtSettings:Issuer"],
              _config["JwtSettings:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(80),
              signingCredentials: credentials);

            return new JwtTokenSettingsDTO
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireTime = token.ValidTo
            }; 
        }

        public bool CheckPassword(string passwordStore, string passwordSent)         
             => Encrypter.DecryptString(passwordStore) == passwordSent;
        
    }
}
