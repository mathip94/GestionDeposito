using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Exceptions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases;

public class ServicioParametro : IServicioParametro
{
    protected IRepositoryParametro _repository;
    protected IMapper _mapper;

    public ServicioParametro(IMapper mapper, IRepositoryParametro repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    private void ThrowExceptionIfItIsNull(ParametroDto parametroDto)
    {
        if (parametroDto == null)
        {
            throw new ElementoInvalidoException("El ParametroDto no puede ser nulo");
        }
    }

    private void ThrowExceptionIfNotExistElement(Parametro parametro)
    {
        if (parametro == null)
        {
            throw new ElementoInvalidoException("No se encontró el elemento solicitado");
        }
    }

    public void Add(ParametroDto parametroDto)
    {
        ThrowExceptionIfItIsNull(parametroDto);
        parametroDto.Validar();
        Parametro Parametro = _mapper.Map<Parametro>(parametroDto);
        _repository.Add(Parametro);
    }

    public ParametroDto Get(string clave)
    {
        Parametro parametro = _repository.Get(clave);
        ThrowExceptionIfNotExistElement(parametro);
        ParametroDto dto = _mapper.Map<ParametroDto>(parametro);
        return dto;
    }

    public void Remove(string clave)
    {
        Parametro parametro = _repository.Get(clave);
        ThrowExceptionIfNotExistElement(parametro);
        _repository.Remove(parametro);
    }

    public void Update(string clave, ParametroDto parametroDto)
    {
        ThrowExceptionIfItIsNull(parametroDto);
        parametroDto.Validar();
        Parametro parametro = _repository.Get(clave);
        ThrowExceptionIfNotExistElement(parametro);
        Parametro parametroToCopy = _mapper.Map<Parametro>(parametroDto);
        parametro.Copy(parametroToCopy);
        _repository.Update(parametro);
    }

    public IEnumerable<ParametroDto> GetManyByKey(string clave)
    {
        IEnumerable<Parametro> parametros = _repository.GetManyByKey(clave);
        IEnumerable<ParametroDto> parametroDto = _mapper.Map<IEnumerable<ParametroDto>>(parametros);
        return parametroDto;
    }
}
