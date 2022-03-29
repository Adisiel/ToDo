using Application.DTOs;
using Application.DTOs.CategoriaDTO;
using Application.Services.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DetailsCategoriaDTO> Add(AddCategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _repository.Add(categoria);
            return _mapper.Map<DetailsCategoriaDTO>(categoria);
        }

        public async Task Delete(DetailsCategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _repository.Delete(categoria);
        }

        public async Task<DetailsCategoriaDTO> Update(UpdateCategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _repository.Update(categoria);
            return _mapper.Map<DetailsCategoriaDTO>(categoria);
        }

        public async Task<List<DetailsCategoriaDTO>?> ObterTodasCategorias()
        {
            var categorias = await _repository.ObterTodasCategorias();
            return _mapper.Map<List<DetailsCategoriaDTO>>(categorias);
        }

        public async Task<DetailsCategoriaDTO> ObterCategoriaPorId(int id)
        {
            var categoria = await _repository.ObterCategoriaPorId(id);
            return _mapper.Map<DetailsCategoriaDTO>(categoria);
        }
    }
}
