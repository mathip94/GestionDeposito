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
    public class ServicioTipoDeMovimiento : ServicioCRUD<TipoDeMovimiento, TipoDeMovimientoDto>, IServicioTipoDeMovimiento
    {
        private IRepositoryTipoDeMovimiento _repository;

        public ServicioTipoDeMovimiento(IMapper mapper, IRepositoryTipoDeMovimiento repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public TipoDeMovimientoResponseDto GetAll()
        {
            TipoDeMovimientoResponseDto tipo = _repository.GetAll();
            return tipo;
        }

        public TipoDeMovimientoResponseDto GetByName(string name, int skip, int take)
        {
            List<TipoDeMovimientoDto> tiposDto = new List<TipoDeMovimientoDto>();
            TipoDeMovimientoResponseDto tipoResponse = _repository.GetByName(name, skip, take);

            return tipoResponse;
        }

        public void Remove(int id)
        {
            if (_repository.IsTipoUsed(id))
            {
                throw new InvalidOperationException("No se puede eliminar un tipo de movimiento que ya está siendo utilizado.");
            }
            TipoDeMovimiento model = _repository.Get(id);
            ThrowExceptionIfNotExistElement(model);
            _repository.Remove(model);
        }

        public void Update(int id, TipoDeMovimientoDto dto)
        {
            ThrowExceptionIfItIsNull(dto);
            dto.Validar();
            if (_repository.IsTipoUsed(id))
            {
                throw new InvalidOperationException("No se puede modificar un tipo de movimiento que ya está siendo utilizado.");
            }
            TipoDeMovimiento model = _repository.Get(id);
            ThrowExceptionIfNotExistElement(model);
            TipoDeMovimiento modelToCopy = _mapper.Map<TipoDeMovimiento>(dto);
            model.Copy(modelToCopy);
            _repository.Update(model);
        }

    }
}
