using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class UsuarioDtoRead : IValidable
    {
        public string Email { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string PasswordEncriptado { get; set; } 
        public bool EsEncargado {  get; set; }

        public void Validar()
        {
            if (Password.Length < 6)
            {
                throw new Exception("La contrasena debe tener al menos 6 digitos.");
            }

            if (!Password.Any(char.IsUpper))
            {
                throw new Exception("La contrasena debe tener al menos 1 letra mayuscula.");
            }

            if (!Password.Any(char.IsLower))
            {
                throw new Exception("La contrasena debe tener al menos 1 letra minuscula.");
            }

            if (!Password.Any(char.IsDigit))
            {
                throw new Exception("La contrasena debe tener al menos 1 numero.");
            }

            string puntuaciones = ".;,!";
            if (!Password.Any(c => puntuaciones.Contains(c)))
            {
                throw new Exception("La contrasena debe tener al menos un signo de puntuacion");
            }

            if (!ValidarEmail())
            {
                throw new Exception("El mail no cumple con el formato de mail");
            }

            if (!ValidarNombre())
            {
                throw new Exception("El nombre contiene caracteres extranos");
            }

            if (!ValidarApellido())
            {
                throw new Exception("El apellido contiene caracteres extranos");
            }

        }
        public bool ValidarEmail()
        {
            // Expresión regular para validar el formato del email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(Email, emailPattern);
        }

        public bool ValidarNombre()
        {
            // Validar que el nombre solamente contiene caracteres alfabéticos, espacio, apóstrofe o guión del medio
            // y que los caracteres no alfabéticos no están al principio ni al final de la cadena
            string namePattern = @"^[a-zA-Z][a-zA-Z\s'-]*[a-zA-Z]$";
            return Regex.IsMatch(Nombre, namePattern);
        }

        public bool ValidarApellido()
        {
            string namePattern = @"^[a-zA-Z][a-zA-Z\s'-]*[a-zA-Z]$";
            return Regex.IsMatch(Apellido, namePattern);
        }
    }
}
