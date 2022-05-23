using Core.Enums;

namespace Application.DTOs.TarefaDTO
{
    public class AddTarefaDTO
    {
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Prioridade { get; set; } = null!;
        public DateTime DataEntrega { get; set; }
        public int CategoriaId { get; set; }
    }
}
