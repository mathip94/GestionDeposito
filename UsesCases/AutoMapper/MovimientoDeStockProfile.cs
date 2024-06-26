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
    public class MovimientoDeStockProfile : Profile
    {
        public MovimientoDeStockProfile()
        {
        //    CreateMap<MovimientoDeStockDto, MovimientoDeStock>();
        //    CreateMap<MovimientoDeStock, MovimientoDeStockDto>().ForMember(dest => dest.TipoDeMovimientoDto, act => act.MapFrom(src => src.TipoDeMovimiento))
        //                                                        .ForMember(dest => dest.ArticuloDto, act => act.MapFrom(src => src.Articulo))
        //                                                        .ForMember(dest => dest.EmpleadoDto, act => act.MapFrom(src => src.Empleado));
        //}

        CreateMap<MovimientoDeStockDto, MovimientoDeStock>()
            .ForMember(dest => dest.FechaYHora, opt => opt.MapFrom(src => src.FechaYHora))
            .ForMember(dest => dest.ArticuloId, opt => opt.MapFrom(src => src.ArticuloId))
            .ForMember(dest => dest.TipoDeMovimientoId, opt => opt.MapFrom(src => src.TipoDeMovimientoId))
            .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
            .ForMember(dest => dest.CantidadDeUnidadesMovidas, opt => opt.MapFrom(src => src.CantidadDeUnidadesMovidas));

        // Mapeo de MovimientoDeStock a MovimientoDeStockDto
        CreateMap<MovimientoDeStock, MovimientoDeStockDto>()
            .ForMember(dest => dest.FechaYHora, opt => opt.MapFrom(src => src.FechaYHora))
            .ForMember(dest => dest.ArticuloId, opt => opt.MapFrom(src => src.ArticuloId))
            .ForMember(dest => dest.TipoDeMovimientoId, opt => opt.MapFrom(src => src.TipoDeMovimientoId))
            .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
            .ForMember(dest => dest.CantidadDeUnidadesMovidas, opt => opt.MapFrom(src => src.CantidadDeUnidadesMovidas));
        }
    }
}
