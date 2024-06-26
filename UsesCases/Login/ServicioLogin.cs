using DataAccess;
using Domain.Dtos;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public class ServicioLogin : IServicioLogin<LoginDto, LoginOutDto>
    {
        private IRepositoryUsuario<Usuario> _repository;
        private readonly JwtSettings _jwtSettings;

        public ServicioLogin(IRepositoryUsuario<Usuario> repository, IOptions<JwtSettings> jwtSettings)
        {
            _repository = repository;
            _jwtSettings = jwtSettings.Value;
        }

        public LoginOutDto Login(LoginDto loginDto)
        {
            Usuario usuario = _repository.GetByMail(loginDto.email);
            if (usuario == null)
            {
                throw new ElementoNoExisteException("No se encontró el usuario");
            }

            if (usuario.Password.CompareTo(loginDto.password) != 0)
            {
                throw new ElementoInvalidoException("Credenciales inválidas");
            }

            if (usuario.EsEncargado == false)
            {
                throw new Exception("Solo los encargados pueden acceder al sistema");
            }

            //acá tenemos que firmar el token
            return new LoginOutDto
            {
                nombre = usuario.Nombre,
                email = loginDto.email,
                token = GenerarTokenJwt(usuario.Nombre, "Encargado")
            };
        }

        private string GenerarTokenJwt(String name, String role)
        {
            // Clave secreta para firmar el token
            // esta clave la tenes que poner en el appsetings.json o en un lugar que no este en el codigo fuente para que no la vea todo el mundo
            //como es un ejemplo aca mostramos como es simplemente
            var claveSecreta = _jwtSettings.SecretKey;

            // Crear los claims (información asociada al token) aca se puede poner si es admin o no por ejemplo
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,name),
                new Claim(ClaimTypes.Role,role)// aca podes crear mas claims por ejemplo los rolees "Role", "Admin
            };

            // Crear la clave de seguridad usando la clave secreta
            var clave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveSecreta));

            // Generar el token JWT
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(clave, SecurityAlgorithms.HmacSha256)
            );

            // Convertir el token en una cadena
            String tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
