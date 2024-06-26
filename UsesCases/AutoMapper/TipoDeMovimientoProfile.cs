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
    public class TipoDeMovimientoProfile : Profile
    {
        public TipoDeMovimientoProfile()
        {
            CreateMap<TipoDeMovimiento, TipoDeMovimientoDto>();
            CreateMap<TipoDeMovimientoDto, TipoDeMovimiento>();
        }
    }
}
