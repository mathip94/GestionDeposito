using DataAccess;
using Domain.Dtos;
using Domain.Models;
using AutoMapper;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public class ServicioUsuario : ServicioCRUD<Usuario, UsuarioDtoRead>, IServicioUsuario
    {
        private IRepositoryUsuario<Usuario> _repository;

        public ServicioUsuario(IMapper mapper, IRepositoryUsuario<Usuario> repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public IEnumerable<UsuarioDtoRead> GetByName(string nombre)
        {
            IEnumerable<Usuario> usuario = _repository.GetByName(nombre);
            IEnumerable<UsuarioDtoRead> usuarioDto = _mapper.Map<IEnumerable<UsuarioDtoRead>>(usuario);
            return usuarioDto;
        }

        public IEnumerable<UsuarioDtoSend> GetAll()
        {
            IEnumerable<Usuario> usuario = _repository.GetAll();
            IEnumerable<UsuarioDtoSend> usuarioDtos = _mapper.Map<IEnumerable<UsuarioDtoSend>>(usuario); ;
            return usuarioDtos;
        }

        public UsuarioDtoRead GetByMail(string email)
        {
            Usuario usuario = _repository.GetByMail(email);
            UsuarioDtoRead usuarioDto = _mapper.Map<UsuarioDtoRead>(usuario);
            return usuarioDto;
        }

        public UsuarioDtoRead Add(UsuarioDtoRead usuarioDto) //Hay que cambiar las validaciones y ponerlas dentro de Validar()
        {
            ThrowExceptionIfItIsNull(usuarioDto);
            usuarioDto.Validar();

            Usuario existeUsuario = _repository.GetByMail(usuarioDto.Email);

            if (existeUsuario != null)
            {
                throw new Exception("El usuario ya existe en la base de datos.");
            }
            Usuario model = _mapper.Map<Usuario>(usuarioDto);
            model.EncriptarPassword();
            Usuario newModel = _repository.Add(model);
            UsuarioDtoRead newDto = _mapper.Map<UsuarioDtoRead>(newModel);

            return newDto;
        }

        //public UsuarioDtoSend Login(string email, string pass)
        //{
        //    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass)) throw new Exception("Datos vacios");
        //    Usuario u = _repository.GetByMail(email);

        //    if (u == null || u.Password != pass) throw new Exception("El email o contrasena son incorrectos");

        //    Usuario model = u;
        //    UsuarioDtoSend dto = _mapper.Map<UsuarioDtoSend>(model);
        //    return dto;
        //}

        public void Update(string mail, UsuarioDtoRead dto)
        {
            ThrowExceptionIfItIsNull(dto);
            dto.Validar();

            Usuario model = _repository.GetByMail(mail);
            ThrowExceptionIfNotExistElement(model);
            Usuario modelToCopy = _mapper.Map<Usuario>(dto);
            model.Copy(modelToCopy);
            _repository.Update(model);
        }

        public void Remove(string email)
        {
            Usuario model = _repository.GetByMail(email);
            ThrowExceptionIfNotExistElement(model);
            _repository.Remove(model);
        }
    }
}
