using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Domain.Interfaces;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata;
using AutoMapper;

namespace UsesCases
{
    public class ServicioCRUD<Model, Dto> : IServicioCRUD<Dto>
        where Model : ICopiable<Model>
        where Dto : IValidable
    {
        protected IRepository<Model> _repository;
        protected IMapper _mapper;

        public ServicioCRUD(IMapper mapper, IRepository<Model> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void ThrowExceptionIfItIsNull(Dto dto)
        {
            if (dto == null)
            {
                throw new ElementoInvalidoException("El DTO no puede ser nulo");
            }
        }

        public void ThrowExceptionIfNotExistElement(Model model)
        {
            if (model == null)
            {
                throw new ElementoNoExisteException("No se encontró el elemento solicitado");
            }
        }

        public Dto Add(Dto dto)
        {
            ThrowExceptionIfItIsNull(dto);
            dto.Validar();
            Model model = _mapper.Map<Model>(dto);
            Model newModel = _repository.Add(model);
            Dto newDto = _mapper.Map<Dto>(newModel);

            return newDto;
        }

        public Dto Get(int id)
        {
            Model model = _repository.Get(id);
            ThrowExceptionIfNotExistElement(model);
            Dto dto = _mapper.Map<Dto>(model);
            return dto;
        }

        public void Remove(int id)
        {
            Model model = _repository.Get(id);
            ThrowExceptionIfNotExistElement(model);
            _repository.Remove(model);
        }

        public void Update(int id, Dto dto)
        {
            ThrowExceptionIfItIsNull(dto);
            dto.Validar();

            Model model = _repository.Get(id);
            ThrowExceptionIfNotExistElement(model);
            Model modelToCopy = _mapper.Map<Model>(dto);
            model.Copy(modelToCopy);
            _repository.Update(model);
        }
    }
}
