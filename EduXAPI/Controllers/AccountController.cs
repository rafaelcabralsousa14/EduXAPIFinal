﻿using EduXAPI.Domains;
using EduXAPI.DTO;
using EduXAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EduXAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private iConta _contaRepositorio;

        public AccountController(IConfiguration config, iConta contaRepositorio)
        {
            _config = config;
            _contaRepositorio = contaRepositorio;
        }

        // Usamos a anotação "AllowAnonymous" para 
        // ignorar a autenticação neste método, já que é ele quem fará isso
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(Login login)
        {

            // Autenticamos o usuário da API
            var user = _contaRepositorio.Login(login.Email, login.Senha);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                return Ok(new { token = tokenString });
            }

            return NotFound();
        }

        // Usamos a anotação "AllowAnonymous" para 
        // ignorar a autenticação neste método, já que é ele quem fará isso
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(Register register)
        {
            try
            {
                // Autenticamos o usuário da API
                var usuario = _contaRepositorio.Register(register.Nome, register.Email, register.Senha, "Comum");

                if (usuario != null)
                {
                    var tokenString = GenerateJSONWebToken(usuario);
                    return Ok(new { token = tokenString });

                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Criamos nosso método que vai gerar nosso Token
        private string GenerateJSONWebToken(Usuarios userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.Tipo),
                new Claim("role", userInfo.Tipo),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.IdUsuario.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    _config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
