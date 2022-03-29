using Application.DTOs;
using Application.DTOs.CategoriaDTO;

namespace Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        public Task<DetailsCategoriaDTO> Add(AddCategoriaDTO categoriaDTO);
        public Task<DetailsCategoriaDTO> Update(UpdateCategoriaDTO categoriaDTO);
        public Task Delete(DetailsCategoriaDTO categoriaDTO);
        public Task<List<DetailsCategoriaDTO>?> ObterTodasCategorias();
        public Task<DetailsCategoriaDTO> ObterCategoriaPorId(int id);
    }
}
