using Application.DTOs.TarefaDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _service;

        public TarefaController(ITarefaService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTarefaDTO addTarefaDTO)
        {
            var detailsTarefaDTO = await _service.Add(addTarefaDTO);

            return CreatedAtAction(nameof(GetById), new { id = detailsTarefaDTO.Id }, detailsTarefaDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTarefaDTO updateTarefaDTO)
        {
            if (!ExisteTarefa(updateTarefaDTO.Id).Result)
            {
                return NotFound("Tarefa não encontrada!");
            }

            var detailsTarefaDTO = await _service.Update(updateTarefaDTO);

            return Ok(detailsTarefaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ExisteTarefa(id).Result)
            {
                return NotFound("Tarefa não encontrada!");
            }

            await _service.Delete(await _service.ObterTarefaPorId(id));

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tarefas = await _service.ObterTodasTarefas();

            if (tarefas == null || !tarefas.Any())
            {
                return NotFound("Nenhuma tarefa encontrada!");
            }

            return Ok(tarefas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarefa = await _service.ObterTarefaPorId(id);

            if (tarefa == null)
            {
                return NotFound("Tarefa não encontrada!");
            }

            return Ok(tarefa);
        }

        private async Task<bool> ExisteTarefa(int id)
        {
            var tarefa = await _service.ObterTarefaPorId(id);
            return tarefa != null;
        }
    }
}
