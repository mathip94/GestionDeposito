using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public class ServicioMovimientoDeStock : ServicioCRUD<MovimientoDeStock, MovimientoDeStockDto>, IServicioMovimientoDeStock
    {
        private IRepositoryMovimientoDeStock _repository;
        private IRepositoryUsuario<Usuario> _repositoryUsuario;
        private IServicioParametro _servicioParametros;
        private readonly static string TOPE_VALUE = "TOPE";

        public ServicioMovimientoDeStock(IMapper mapper, IRepositoryMovimientoDeStock repository, IRepositoryUsuario<Usuario> repositoryU, IServicioParametro servicioParametros) : base(mapper, repository)
        {
            _repository = repository;
            _repositoryUsuario = repositoryU;
            _servicioParametros = servicioParametros;
        }

        public IEnumerable<MovimientoDeStockDto> GetAll()
        {
            IEnumerable<MovimientoDeStock> movimientosDeStocks = _repository.GetAll();
            IEnumerable<MovimientoDeStockDto> movimientosDeStocksDto = _mapper.Map<IEnumerable<MovimientoDeStockDto>>(movimientosDeStocks); ;
            return movimientosDeStocksDto;
        }

        public ArticuloResponseDto GetArticuloConMovimientosEnRangoDeFechas(DateTime fechaInicio, DateTime fechaFin, int skip, int take)
        {
            List<ArticuloDto> articuloDto = new List<ArticuloDto>();
            ArticuloResponseDto articuloResponse = _repository.GetArticuloConMovimientosEnRangoDeFechas(fechaInicio, fechaFin, skip, take);

            return articuloResponse;
        }

        public MovimientoDeStockResponseDto GetMovimientosPorArticuloYTipo(int articuloId, int tipoDeMovimientoId, int skip, int take)
        {
            List<MovimientoDeStockDto> movimientoDto = new List<MovimientoDeStockDto>();
            MovimientoDeStockResponseDto movimientoResponse = _repository.GetMovimientosPorArticuloYTipo(articuloId, tipoDeMovimientoId, skip, take);

            return movimientoResponse;
        }

        public ResumenResponseDto GetResumenMovimientos()
        {
            ResumenResponseDto resumenResponse = _repository.GetResumenMovimientos();
            return resumenResponse;
        }

        public MovimientoDeStockDto Add(MovimientoDeStockDto dto)
        {
            ThrowExceptionIfItIsNull(dto);
            dto.Validar();
            dto.UsuarioId = _repositoryUsuario.GetByMail(dto.MailUsuario).Id;
            
            double TopeMovimiento = Double.Parse(_servicioParametros.Get(TOPE_VALUE).Valor);

            if (dto.CantidadDeUnidadesMovidas > TopeMovimiento)
            {
                throw new Exception($"No se puede mover mas de {TopeMovimiento} unidades");
            }

            MovimientoDeStock model = _mapper.Map<MovimientoDeStock>(dto);
            MovimientoDeStock newModel = _repository.Add(model);
            MovimientoDeStockDto newDto = _mapper.Map<MovimientoDeStockDto>(newModel);

            return newDto;
        }
    }
}
