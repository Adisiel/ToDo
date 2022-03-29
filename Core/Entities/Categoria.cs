namespace Core.Entities
{
    public class Categoria
    {
        public Categoria(string nome, string cor)
        {
            Nome = nome;
            Cor = cor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
    }
}
