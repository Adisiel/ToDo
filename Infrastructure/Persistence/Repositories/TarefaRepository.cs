using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ToDoContext _context;

        public TarefaRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task Add(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Tarefa tarefa)
        {
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tarefa>?> ObterTodasTarefas()
        {
            var tarefas = await _context.Tarefas.Include(t => t.Categoria).AsNoTracking().ToListAsync();
            return tarefas;
        }

        public async Task<Tarefa?> ObterTarefaPorId(int id)
        {
            var tarefa = await _context.Tarefas.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
            return tarefa;
        }
    }
}
