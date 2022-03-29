using Application.DTOs.TarefaDTO;
using Application.Services.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        private readonly IMapper _mapper;
        public TarefaService(ITarefaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DetailsTarefaDTO> Add(AddTarefaDTO addTarefaDTO)
        {
            var tarefa = _mapper.Map<Tarefa>(addTarefaDTO);
            await _repository.Add(tarefa);
            return _mapper.Map<DetailsTarefaDTO>(tarefa);
        }

        public async Task Delete(DetailsTarefaDTO detailsTarefaDTO)
        {
            var tarefa = _mapper.Map<Tarefa>(detailsTarefaDTO);
            await _repository.Delete(tarefa);
        }

        public async Task<DetailsTarefaDTO> Update(UpdateTarefaDTO updateTarefaDTO)
        {
            var tarefa = _mapper.Map<Tarefa>(updateTarefaDTO);
            await _repository.Update(tarefa);
            return _mapper.Map<DetailsTarefaDTO>(tarefa);
        }

        public async Task<List<DetailsTarefaDTO>?> ObterTodasTarefas()
        {
            var tarefas = await _repository.ObterTodasTarefas();
            return _mapper.Map<List<DetailsTarefaDTO>>(tarefas);
        }

        public async Task<DetailsTarefaDTO> ObterTarefaPorId(int id)
        {
            var tarefa = await _repository.ObterTarefaPorId(id);
            return _mapper.Map<DetailsTarefaDTO>(tarefa);
        }
    }
}
