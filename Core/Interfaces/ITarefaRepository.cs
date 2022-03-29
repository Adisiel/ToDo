using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        public Task Add(Tarefa tarefa);
        public Task Update(Tarefa tarefa);
        public Task Delete(Tarefa tarefa);
        public Task<List<Tarefa>?> ObterTodasTarefas();
        public Task<Tarefa?> ObterTarefaPorId(int id);
    }
}
