
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases 
{ 
    public class ServicioArticulo : ServicioCRUD<Articulo, ArticuloDto>, IServicioArticulo
    {
        private IRepositoryArticulo _repository;

        public ServicioArticulo(IMapper mapper, IRepositoryArticulo repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public ArticuloDto GetByName(string nombre)
        {
            Articulo articulo = _repository.GetByName(nombre);
            ArticuloDto articuloDto = _mapper.Map<ArticuloDto>(articulo);
            return articuloDto;
        }

        public ArticuloDto GetByCodigo(string codigo) 
        {
            Articulo articulo = _repository.GetByCodigo(codigo);
            ArticuloDto articuloDto = _mapper.Map<ArticuloDto>(articulo);
            return articuloDto;
        }

        public ArticuloResponseDto GetAll()
        {
            ArticuloResponseDto articulos = _repository.GetAll();
            return articulos;
        }

        public ArticuloDto Add(ArticuloDto articuloDto)
        {
            ThrowExceptionIfItIsNull(articuloDto);
            articuloDto.Validar();

            Articulo model = _mapper.Map<Articulo>(articuloDto);
            
            Articulo existeArticuloNombre = _repository.GetByName(model.Nombre);
            Articulo existeArticuloCodigo = _repository.GetByCodigo(model.Codigo);


            if (existeArticuloNombre != null)
            {
                throw new Exception("Ya existe un articulo con ese nombre.");
            }
            if (existeArticuloCodigo != null)
            {
                throw new Exception("Ya existe un articulo con ese codigo.");
            }

            Articulo newModel = _repository.Add(model);
            ArticuloDto newDto = _mapper.Map<ArticuloDto>(newModel);

            return newDto;
        }
    }
}
