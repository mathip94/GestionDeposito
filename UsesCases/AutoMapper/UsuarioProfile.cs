using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDtoRead>();
            CreateMap<UsuarioDtoRead, Usuario>();
            CreateMap<Usuario, UsuarioDtoSend>();
            CreateMap<UsuarioDtoSend, Usuario>();
        }
    }
}
