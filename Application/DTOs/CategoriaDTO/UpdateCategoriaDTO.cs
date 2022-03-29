namespace Application.DTOs.CategoriaDTO
{
    public class UpdateCategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cor { get; set; } = null!;
    }
}
