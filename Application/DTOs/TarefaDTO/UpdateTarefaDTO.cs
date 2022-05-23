using Core.Enums;

namespace Application.DTOs.TarefaDTO
{
    public class UpdateTarefaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Prioridade { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime DataEntrega { get; set; }
        public int CategoriaId { get; set; }
    }
}
