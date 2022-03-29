using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ToDoContext _context;

        public CategoriaRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Categoria categoria)
        {
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Categoria>?> ObterTodasCategorias()
        {
            var categorias = await _context.Categorias.AsNoTracking().ToListAsync();
            return categorias;
        }

        public async Task<Categoria?> ObterCategoriaPorId(int id)
        {
            var categoria = await _context.Categorias.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
            return categoria;
        }
    }
}
