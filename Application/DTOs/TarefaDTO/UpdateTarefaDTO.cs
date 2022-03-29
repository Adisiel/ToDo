using Core.Enums;

namespace Application.DTOs.TarefaDTO
{
    public class UpdateTarefaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public Prioridade Prioridade { get; set; }
        public Status Status { get; set; }
        public DateTime DataEntrega { get; set; }
        public int CategoriaId { get; set; }
    }
}
