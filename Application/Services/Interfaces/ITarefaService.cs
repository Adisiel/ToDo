using Application.DTOs.TarefaDTO;

namespace Application.Services.Interfaces
{
    public interface ITarefaService
    {
        public Task<DetailsTarefaDTO> Add(AddTarefaDTO addTarefaDTO);
        public Task<DetailsTarefaDTO> Update(UpdateTarefaDTO updateTarefaDTO);
        public Task Delete(DetailsTarefaDTO detailsTarefaDTO);
        public Task<List<DetailsTarefaDTO>?> ObterTodasTarefas();
        public Task<DetailsTarefaDTO> ObterTarefaPorId(int id);
    }
}
