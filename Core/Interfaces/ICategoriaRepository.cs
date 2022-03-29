using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        public Task Add(Categoria categoria);
        public Task Update(Categoria categoria);
        public Task Delete(Categoria categoria);
        public Task<List<Categoria>?> ObterTodasCategorias();
        public Task<Categoria?> ObterCategoriaPorId(int id);
    }
}
