using Application.DTOs.CategoriaDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoriaDTO addCategoriaDTO)
        {   
            var detailsCategoriaDTO = await _service.Add(addCategoriaDTO);

            return CreatedAtAction(nameof(GetById), new { id = detailsCategoriaDTO.Id }, detailsCategoriaDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCategoriaDTO updateCategoriaDTO)
        {
            if (!ExisteCategoria(updateCategoriaDTO.Id).Result)
            {
                return NotFound("Categoria não encontrada!");
            }

            var detailsCategoriaDTO = await _service.Update(updateCategoriaDTO);

            return Ok(detailsCategoriaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ExisteCategoria(id).Result)
            {
                return NotFound("Categoria não encontrada!");
            }

            await _service.Delete(await _service.ObterCategoriaPorId(id));

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categorias = await _service.ObterTodasCategorias();

            if (categorias == null || !categorias.Any())
            {
                return NotFound("Nenhuma categoria encontrada!");
            }

            return Ok(categorias);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _service.ObterCategoriaPorId(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada!");
            }

            return Ok(categoria);
        }

        private async Task<bool> ExisteCategoria(int id)
        {
            var categoria = await _service.ObterCategoriaPorId(id);
            return categoria != null;
        }
    }
}
