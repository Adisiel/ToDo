using Core.Enums;

namespace Core.Entities
{
    public class Tarefa
    {
        public Tarefa(string titulo, string descricao, Prioridade prioridade, Status status, DateTime dataEntrega, int categoriaId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = status;
            DataEntrega = dataEntrega;
            CategoriaId = categoriaId;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Prioridade Prioridade { get; set; }
        public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
    }
}
